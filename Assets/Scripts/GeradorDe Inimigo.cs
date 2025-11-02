using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigo : MonoBehaviour
{
    // Prefab do inimigo (arraste no Inspector)
    public GameObject LesmaBasicaPrefab;
    public GameObject LesmaBarrilPrefab;

    // Intervalo entre spawns (segundos)
    public float intervalo = 1f;

    // Limites de spawn no cenário
    public float limiteX = 8f;
    public float limiteY = 4f;

    // Velocidade de movimento dos inimigos
    public float velocidade = 3f;
    int Enemy;

    // Limite X para destruir o inimigo ao sair da tela
    public float limiteDestruicaoX = -14f;

    void Start()
    {
        // Começa a gerar inimigos repetidamente
        InvokeRepeating("GerarInimigo", 0f, intervalo);
    }
    void Update()
    {
        Enemy = Random.Range(1, 3);       
    }

    void GerarInimigo()
    {
        // Define posição de spawn (à direita da tela)
        float x = limiteX;
        float y = limiteY;
        Vector2 posicaoAleatoria = new Vector2(x, y);

        // Instancia o inimigo
        switch (Enemy)
        {
            case 1:
                Instantiate(LesmaBasicaPrefab, posicaoAleatoria, Quaternion.identity);
                break;
            case 2:
                Instantiate(LesmaBarrilPrefab, posicaoAleatoria, Quaternion.identity);
                break;
        }
    }
}
