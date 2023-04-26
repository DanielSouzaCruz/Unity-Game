using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int _powerupID;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if(other.tag == "Player")
        {
            // acessa o player, o primeiro nome e o nome <> devem ser iguais
            Player player = other.GetComponent<Player>();
            // habilita o tiro triplo e verifica se o player foi achado
            if(player != null)
            {
                if(_powerupID == 0)
                {
                  player.TripleShotPowerupOn();  
                }
                else if(_powerupID == 1)
                {
                  player.SpeedBoostPowerupOn();   
                }
               
            }

            // auto destruir
            Destroy(this.gameObject);  
        }
        
    }
}
