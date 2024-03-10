using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player : MonoBehaviour
{
    // Velocidade de movimento do jogador
    public float speed;

    // Força do salto do jogador
    public float jumpForce;

    // Variável que indica se o jogador está pulando
    public bool isJumping;

    // Referência para o componente Animator do jogador
    public Animator anim;

    // Referência para o componente Rigidbody2D do jogador
    private Rigidbody2D rig;

    // Método chamado uma vez antes do primeiro quadro do jogo
    void Start()
    {
        // Obtém uma referência para o componente Rigidbody2D do jogador
        rig = GetComponent<Rigidbody2D>();

        // Obtém uma referência para o componente Animator do jogador
        anim = GetComponent<Animator>();
    }

    // Método chamado uma vez por quadro do jogo
    void Update()
    {
        // Chama os métodos de movimento e salto
        Move();
        Jump();

        // Verifica se o jogador está correndo
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("isRun", true);
        }
        // Verifica se o jogador está parado
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    // Método responsável pelo movimento do jogador
    void Move()
    {
        // Calcula o vetor de movimento com base no eixo horizontal
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        // Move o jogador de acordo com o vetor de movimento e a velocidade, considerando o tempo entre quadros
        transform.position += movement * Time.deltaTime * speed;

        // Verifica se o jogador está se movendo para a esquerda ou para a direita e rotaciona o jogador adequadamente
        float inputAxis = Input.GetAxis("Horizontal");
        if (inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    // Método responsável pelo salto do jogador
    void Jump()
    {
        // Verifica se o botão de salto foi pressionado e o jogador não está pulando
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // Aplica uma força vertical para cima no jogador para realização do salto
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            // Ativa a animação de pulo
            anim.SetBool("isJump", true);
        }
    }
}
