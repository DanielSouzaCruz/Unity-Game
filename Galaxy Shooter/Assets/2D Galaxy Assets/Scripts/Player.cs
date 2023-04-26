using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool canTripleShot = false;
    //serialização: permite que uma variavel privada seja vista no inspetor
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;
    
    private float _nextFire = 0.0f;

    [SerializeField]
    private float _velocidade = 5.0f;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    private void Update()
    {
        // obs: A cada frame, este codigo vai ser chamado
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)){
            Shoot();
        }
    }

    private void Shoot()
    {
        if(Time.time > _nextFire)
            {
                if(canTripleShot == true){
                    Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
                }
                else{
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity); 
              
                }
                 _nextFire = Time.time + _fireRate; 
            }
    }

    private void Movement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput  * _velocidade * Time.deltaTime );  
        transform.Translate(Vector3.up * verticalInput  * _velocidade * Time.deltaTime );  
        
        if(transform.position.y >5f){
            transform.position = new Vector3(transform.position.x,-5f,0);
        }
        else if(transform.position.y< -5f){
            transform.position = new Vector3(transform.position.x,5f,0);
        }

        if(transform.position.x< -9.2f){
            transform.position = new Vector3(9.2f,transform.position.y,0);
        }
        else if(transform.position.x> 9.2f){
            transform.position = new Vector3(-9.2f, transform.position.y,0);
        }
    }

    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }
}
