using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //serialização: permite que uma variavel privada seja vista no inspetor
    [SerializeField]
    private float velocidade = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        // obs: A cada frame, este codigo vai ser chamado
        Movement();
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
