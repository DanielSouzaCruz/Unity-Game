using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool isCoopMode = false;   
    public bool gameOver = true;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject _coopPlayers;
    private SpawnManager _spawnManager;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        if(gameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(isCoopMode == false)
                {
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Instantiate(_coopPlayers, Vector3.zero, Quaternion.identity);
                }
                gameOver = false;
                _uiManager.HideTitleScreen();
                _spawnManager.StartSpawnRoutines();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Menu");
            }
        }       
    }
}
