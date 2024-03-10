using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class salvaHighScore : MonoBehaviour
{
    // Referencia ao texto da maior pontuacao UI
    public Text highScoreText;
    
    // Maior pontuacao alcancada
    private float highScore = 0f;
    private void Awake()
    {
        // Carrega a maior pontuação salva
        highScore = PlayerPrefs.GetFloat("HighScore", 0);

        // Atualiza o texto da maior pontuação
        highScoreText.text = "High Score: " + highScore.ToString("0");

        // mantem este objeto vivo entre as cenas
        DontDestroyOnLoad(gameObject);
    }

    // Método para definir um novo high score
    public void SetHighScore(float score)
    {
        highScore = score;
        PlayerPrefs.SetFloat("HighScore", highScore);
        highScoreText.text = "High Score: " + highScore.ToString("0");
    }
    // Método para obter o high score atual
     public float GetHighScore()
    {
        return highScore;
    }
}
