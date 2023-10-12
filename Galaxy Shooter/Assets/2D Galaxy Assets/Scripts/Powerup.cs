using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int _powerupID;

    [SerializeField]
    private AudioClip _clip;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if(other.tag == "Player")
        {
            // acessa o player, o primeiro nome e o nome <> devem ser iguais
            Player player = other.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
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
                else if(_powerupID == 2)
                {
                    player.ShieldExtraPowerupOn();
                }
               
            }

            // auto destruir
            Destroy(this.gameObject);  
        }
        
    }
}
