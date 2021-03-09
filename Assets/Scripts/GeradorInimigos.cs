using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{

    public GameObject[] cactoPrefabs;

    public GameObject dinossauroVoadorPrefab;
    public float dealyInicial;
    public float delayEntreCactos;

    public float distanciaMinima = 4;

    public float distanciaMaxima = 8;

    public float dinossauroVoadorYMinimo = -1;
    public float dinossauroVoadorYMaximo = 1;
    // Start is called before the first frame update
    public float dinossauroVoadorPontuacaoMinima = 300;

    public Jogador jogadorScript;
    private void Start()
    {
        // InvokeRepeating("GerarInimigo", dealyInicial, delayEntreCactos);
        StartCoroutine(GerarInimigo());
    }

    // Update is called once per frame
    private IEnumerator GerarInimigo()
    {
        yield return new WaitForSeconds(dealyInicial);

        GameObject ultimoInimigoGerado = null;

        var distanciaNecessaria = 0f;

        while (true)
        {
            var geracaoObjetoLiberada = ultimoInimigoGerado == null || Vector3.Distance(transform.position, ultimoInimigoGerado.transform.position) >= distanciaNecessaria;

            if (geracaoObjetoLiberada)
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

                    ultimoInimigoGerado = Instantiate(dinossauroVoadorPrefab, posicao, Quaternion.identity);
                }
                else
                {
                    var quantidadeCactos = cactoPrefabs.Length;
                    var indiceAleatorio = Random.Range(0, quantidadeCactos);
                    var cactoPrefab = cactoPrefabs[indiceAleatorio];
                    ultimoInimigoGerado = Instantiate(cactoPrefab, transform.position, Quaternion.identity);
                }
                distanciaNecessaria = Random.Range(distanciaMinima, distanciaMaxima);
            }
            yield return null;
            // yield return new WaitForSeconds(delayEntreCactos);
        }
    }
}
