using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{

    public GameObject[] cactoPrefabs;

    public GameObject dinossauroVoadorPrefab;
    public float dealyInicial;
    public float delayEntreCactos;

    public float dinossauroVoadorYMinimo = -1;
    public float dinossauroVoadorYMaximo = 1;
    // Start is called before the first frame update
    public float dinossauroVoadorPontuacaoMinima = 300;

    public Jogador jogadorScript;
    private void Start()
    {
        InvokeRepeating("GerarInimigo", dealyInicial, delayEntreCactos);
    }

    // Update is called once per frame
    private void GerarInimigo()
    {
        var dado = Random.Range(1, 7);
        if (jogadorScript.pontos >= dinossauroVoadorPontuacaoMinima && dado <= 2)
        {
            var posicaoYAleatoria = Random.Range(dinossauroVoadorYMinimo, dinossauroVoadorYMaximo);
            var posicao = new Vector3(
                transform.position.x,
                transform.position.y + posicaoYAleatoria,
                transform.position.z
            );

            Instantiate(dinossauroVoadorPrefab, posicao, Quaternion.identity);
        }
        else
        {
            var quantidadeCactos = cactoPrefabs.Length;
            var indiceAleatorio = Random.Range(0, quantidadeCactos);
            var cactoPrefab = cactoPrefabs[indiceAleatorio];
            Instantiate(cactoPrefab, transform.position, Quaternion.identity);
        }
    }
}
