using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Sprite[] lives;
    public Image livesImageDisplay;

    // Start is called before the first frame update
    public void UpdateLives(int currentLives)
    {
        Debug.Log("Player lives:" + currentLives);
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {

    }
}
