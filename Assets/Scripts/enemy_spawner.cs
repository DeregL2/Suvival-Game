using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    // Taxa de spawn dos inimigos (inimigos por segundo)
    [SerializeField] private float spawnRate = 1f;

    // Array de prefabs dos inimigos que podem ser gerados
    [SerializeField] private GameObject[] enemyPrefab;

    // Flag indicando se o spawner pode gerar inimigos
    [SerializeField] private bool canSpawn = true;

    // Método chamado quando o script é iniciado
    private void Start()
    {
        // Inicia a rotina de spawn
        StartCoroutine(Spawner());
    }

    // Corrotina responsável por gerar os inimigos em intervalos regulares
    private IEnumerator Spawner()
    {
        // Cria um WaitForSeconds para aguardar o intervalo de spawn
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        // Loop infinito enquanto o spawner pode gerar inimigos
        while (canSpawn)
        {
            // Aguarda o intervalo de spawn
            yield return wait;

            // Escolhe aleatoriamente um inimigo do array de prefabs
            int rand = Random.Range(0, enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[rand];

            // Instancia o inimigo na posição do spawner
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
