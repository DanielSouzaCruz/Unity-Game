using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);
        if(transform.position.y < -9f)
        {
            transform.position = new Vector3(Random.Range(-8.0f,8.0f),9f,0);
        }
        
    }
}
