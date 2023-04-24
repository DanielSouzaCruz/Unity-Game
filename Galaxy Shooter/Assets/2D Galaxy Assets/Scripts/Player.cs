using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //serialização: permite que uma variavel privada seja vista no inspetor

    public GameObject laserPrefab;

    public float fireRate = 0.25f;
    public float nextFire = 0.0f;

    [SerializeField]
    private float velocidade = 5.0f;

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
            if(Time.time > nextFire)
            {
              Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity); 
              nextFire = Time.time + fireRate;  
            }
            
        }
    }

    private void Movement()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput  * velocidade * Time.deltaTime );  
        transform.Translate(Vector3.up * verticalInput  * velocidade * Time.deltaTime );  
        
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
}
