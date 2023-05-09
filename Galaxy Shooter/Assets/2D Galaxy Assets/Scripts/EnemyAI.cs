using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyExplosionPrefab;

    [SerializeField]
    private float _enemySpeed = 5f;

    private UIManager _UiManager;

    void Start()
    {
        _UiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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
            Instantiate(_enemyExplosionPrefab, transform.position,Quaternion.identity);
            _UiManager.UpdateScore();
            Destroy(this.gameObject);    
        }

        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            Instantiate(_enemyExplosionPrefab, transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
