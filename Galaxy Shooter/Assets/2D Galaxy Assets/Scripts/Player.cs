using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool canTripleShot = false;
    public bool speedBoost = false;
    public bool shieldExtra = false;

    //serialização: permite que uma variavel privada seja vista no inspetor
    [SerializeField]
    private GameObject _playerExplosionPrefab;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;

    [SerializeField]
    private float _fireRate = 0.25f;
    
    private float _nextFire = 0.0f;

    [SerializeField]
    private float _velocidade = 6.0f;

    private UIManager _uiManager;
    private GameController _gameController;
    private SpawnManager _spawnManager;
    private AudioSource _audioSource;

    public int playerLive = 3;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(0,0,0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if(_uiManager != null)
        {
            _uiManager.UpdateLives(playerLive);
        }

        if(_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutines();
        }

        _audioSource = GetComponent<AudioSource>();
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
                _audioSource.Play();
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

        if(speedBoost == true)
        {
            transform.Translate(Vector3.right * horizontalInput  * _velocidade * 2f * Time.deltaTime );  
            transform.Translate(Vector3.up * verticalInput  * _velocidade * 2f * Time.deltaTime ); 
        }
        else 
        {
           transform.Translate(Vector3.right * horizontalInput  * _velocidade * Time.deltaTime );  
           transform.Translate(Vector3.up * verticalInput  * _velocidade * Time.deltaTime ); 
        }
         
        
        
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

    public void SpeedBoostPowerupOn(){
        speedBoost = true;
        StartCoroutine(SpeedBoostPowerupDownRoutine());
    }

    public void ShieldExtraPowerupOn()
    {
        shieldExtra = true;
        _shieldGameObject.SetActive(true);
    }


    public IEnumerator SpeedBoostPowerupDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speedBoost = false;  
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    public void Damage()
    {
        if(shieldExtra == true)
        {
            shieldExtra = false;
            _shieldGameObject.SetActive(false);
            // metodo para dizer que quando a habilidade for false, ele retorna a damage ao normal
            return;
        }
        playerLive--;
        _uiManager.UpdateLives(playerLive);

        if(playerLive < 1)
        {
            Destroy(this.gameObject);
            _gameController.gameOver = true;
            _uiManager.ShowTitleScreen();
            Instantiate(_playerExplosionPrefab, transform.position,Quaternion.identity);
        }
    }
}
