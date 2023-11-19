using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Sprite[] lives;
    public Image livesImageDisplay;

    public GameObject tittleScreen;
    public TextMeshProUGUI pontuacaoTexto, melhorPontuacaoTexto;
    public int pontuacao, melhorPontuacao;

    // Start is called before the first frame update
    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        pontuacao += 10;
        pontuacaoTexto.text = "Score: " + pontuacao;
    }

    public void CheckBestScore()
    {
        if(pontuacao > melhorPontuacao)
        {
            melhorPontuacao = pontuacao;
            melhorPontuacaoTexto.text = "Best: " + melhorPontuacao;
        }
    }

    public void ShowTitleScreen()
    {
        tittleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        tittleScreen.SetActive(false);
        pontuacaoTexto.text = "Score: ";
        pontuacao = 0;
    }

    public void ResumePlay()
    {
        GameController gc = GameObject.Find("GameController").GetComponent<GameController>();
        gc.ResumeGame();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
