using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Sprite[] lives;
    public Image livesImageDisplay;
    public TextMeshProUGUI pontuacaoTexto;
    public int pontuacao;

    // Start is called before the first frame update
    public void UpdateLives(int currentLives)
    {
        Debug.Log("Player lives:" + currentLives);
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        pontuacao +=10;
        pontuacaoTexto.text = "Score: " + pontuacao;
    }
}
