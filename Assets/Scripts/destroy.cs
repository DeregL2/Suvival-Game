using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Este método é chamado uma vez no início do jogo.
        // Você pode usar este método para inicializar variáveis ou configurar valores iniciais.
    }

    // Update is called once per frame
    void Update()
    {
        // Este método é chamado a cada quadro do jogo.
        // Você pode usar este método para realizar lógica que precisa ser atualizada continuamente, como movimento ou detecção de entrada.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Este método é chamado quando este objeto colide com outro objeto com um colisor 2D.
        // Ele verifica se o objeto colidido está na camada "Inimigo" e, se estiver, o destrói.
        if (collision.gameObject.layer == LayerMask.NameToLayer("Inimigo"))
        {
            Destroy(collision.gameObject);
        }
    }
}
