using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text; // Este using pode não ser necessário, a menos que você esteja usando TextMeshPro.
// using static UnityEditor.Experimental.GraphView.GraphView; // Este using parece desnecessário e pode ser removido.

public class groundCheck : MonoBehaviour
{
    move_player player; // Referência para o componente move_player do jogador

    // Método chamado uma vez antes do primeiro quadro do jogo
    void Start()
    {
        // Obtém uma referência para o componente move_player do pai deste objeto
        player = gameObject.transform.parent.gameObject.GetComponent<move_player>();
    }

    // Método chamado quando este objeto colide com outro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto com o qual colidimos está na camada 3 (que pode ser a camada do chão)
        if (collision.gameObject.layer == 3)
        {
            // Define a variável isJumping do player como false, indicando que não está pulando
            player.isJumping = false;

            // Define a animação de pulo como false
            player.anim.SetBool("isJump", false);
        }
    }

    // Método chamado quando este objeto não está mais colidindo com outro objeto
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verifica se o objeto com o qual não estamos mais colidindo está na camada 3 (que pode ser a camada do chão)
        if (collision.gameObject.layer == 3)
        {
            // Define a variável isJumping do player como true, indicando que está pulando
            player.isJumping = true;
        }
    }
}
