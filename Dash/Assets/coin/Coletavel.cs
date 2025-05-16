using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public GameObject objetoParaSpawnar; // Arraste o seu prefab aqui no Inspector
    public float intervaloDeSpawn = 2f;
    public float limiteXMin = -8f; // Defina os limites mínimos e máximos da tela na horizontal
    public float limiteXMax = 8f;
    public float limiteYMin = -4f; // Defina os limites mínimos e máximos da tela na vertical
    public float limiteYMax = 4f;

    private float tempoDecorrido = 0f;
    public float horaCriar = 2f;
    void Update()
    {
        tempoDecorrido = Time.time;

        if (tempoDecorrido >= horaCriar)
        {
            SpawnarObjeto();
           // tempoDecorrido = 0f;
            horaCriar += intervaloDeSpawn;
            Debug.Log("criou");
        }
    }

    void SpawnarObjeto()
    {
        // Gera uma posição aleatória dentro dos limites definidos
        float posicaoXAleatoria = Random.Range(limiteXMin, limiteXMax);
        float posicaoYAleatoria = Random.Range(limiteYMin, limiteYMax);
        Vector3 posicaoAleatoria = new Vector3(posicaoXAleatoria, posicaoYAleatoria, 0f);

        // Instancia o objeto na posição aleatória
        if (objetoParaSpawnar != null)
        {
            Instantiate(objetoParaSpawnar, posicaoAleatoria, Quaternion.identity);
        }
        else
        {
            Debug.LogError("O objetoParaSpawnar não foi atribuído no Inspector!");
        }
    }
}
