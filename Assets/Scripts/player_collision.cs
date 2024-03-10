using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour
{
    // Método chamado quando este objeto colide com outro objeto
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Verifica se o objeto com o qual colidimos está na camada "Inimigo"
        if (other.gameObject.layer == LayerMask.NameToLayer("Inimigo"))
        {
            // Define a variável isGameOver do GameManager como verdadeira, indicando que o jogo acabou
            GameManager.isGameOver = true;

            // Desativa este objeto (provavelmente o jogador)
            gameObject.SetActive(false);

            // Pausa o tempo do jogo
            Time.timeScale = 0f;
        } 
    }
}
