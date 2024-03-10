using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    // Referência ao texto da pontuação na UI
    public Text scoreValueText;

    //Referencia ao script salvaHighScore
    private salvaHighScore highScoreManager;
    public float scoreValue = 0f;
    

    // Pontuação aumentada por segundo
    public float pointIncreasedPerSecond = 1f;

    // Variável estática indicando se o jogo acabou
    public static bool isGameOver;

    // Tela de Game Over
    public GameObject gameOverScreen;

    // Método chamado quando o objeto é inicializado
    private void Awake()
    {
        // Define a variável isGameOver como false quando o jogo é iniciado
        isGameOver = false;

        // Obtem uma referencia ao objeto salvaHighScore
        highScoreManager = FindObjectOfType<salvaHighScore>();
    }

    // Método chamado a cada quadro do jogo
    void Update()
    {
        // Se o jogo acabou, ativa a tela de Game Over
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            //Verifica se a pontuacao atual e maior que a maior
            if(scoreValue > highScoreManager.GetHighScore())
            {
                //se for, atualiza a maior pontuacao e salva
                highScoreManager.SetHighScore(scoreValue);
            }
        }
    }

    // Método chamado em intervalos fixos de tempo
    private void FixedUpdate()
    {
        // Atualiza o texto da pontuação na UI com o valor atual da pontuação
        scoreValueText.text = ((int) scoreValue).ToString("Score: 0");

        // Incrementa a pontuação ao longo do tempo
        scoreValue += pointIncreasedPerSecond * Time.fixedDeltaTime;
    }

    // Método para reiniciar o jogo
    public void ReplayGame()
    {
        // Carrega a cena atual para reiniciar o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Reseta o tempo do jogo para 1 (tempo normal)
        Time.timeScale = 1f;
    }
}
