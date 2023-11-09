using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _weaponSound;

    [SerializeField]
    private int _currentAmmo;
    private int _maxAmmo = 50;
    private bool _isRealoading = false;
    private UIManager _uiManager;
    [SerializeField]
    private GameObject _weapon;

   
    public bool hasCoin = false;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _currentAmmo = _maxAmmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && _currentAmmo>0)
        {
            Shoot();    
        }
        else
        {
            _muzzleFlash.SetActive(false);
            _weaponSound.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && _isRealoading == false)
        {
            _isRealoading = true;
            StartCoroutine(Reload());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }


        CalculateMovement();
    }

    void Shoot()
    {
        _muzzleFlash.SetActive(true);
        _currentAmmo--;
        _uiManager.UpdateAmmo(_currentAmmo);
        if (_weaponSound.isPlaying == false)
        {
            _weaponSound.Play();
        }
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("hit:" + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
            Destroy(hitMarker, 1f);

            Destructable crate = hitInfo.transform.GetComponent<Destructable>();
            if(crate != null )
            {
                crate.DestroyCrate();
            }
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmo(_currentAmmo);
        _isRealoading = false;
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    public void EnableWeapons()
    {
        _weapon.SetActive(true);
    }
}
