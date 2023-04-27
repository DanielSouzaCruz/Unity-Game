using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        if(transform.position.y < -9f)
        {
            //lembrar de utilizar variaveis para o codigo ficar mais limpo, o meu codigo estava certo apenas não estava "bonito"
            float randomX = Random.Range(-8f,8f);
            transform.position = new Vector3(randomX,9f,0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            if(other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);    
        }

        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
