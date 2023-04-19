using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput  * velocidade * Time.deltaTime );  
        transform.Translate(Vector3.up * verticalInput  * velocidade * Time.deltaTime );  
        
        if(transform.position.y >4.2f){
            transform.position = new Vector3(transform.position.x,4.2f,0);
        }
        else if(transform.position.y< -4.2f){
            transform.position = new Vector3(transform.position.x,-4.2f,0);
        }

        else if(transform.position.x< -8.2f){
            transform.position = new Vector3(-8.2f,transform.position.y,0);
        }
        else if(transform.position.x> 8.2f){
            transform.position = new Vector3(8.2f, transform.position.y,0);
        }

        
        
        //transform.Translate( new Vector3(1,0,0));
    }
}
