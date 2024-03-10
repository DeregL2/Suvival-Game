using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move2 : MonoBehaviour
{
    // Velocidade de movimento do inimigo, ajustável no editor Unity
    public float speed = 1f;

    // Método chamado a cada quadro do jogo
    private void Update()
    {
        // Movimentação horizontal do inimigo
        // Ele se move para a esquerda multiplicando o vetor (-1, 0) pela velocidade e o tempo entre quadros
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
