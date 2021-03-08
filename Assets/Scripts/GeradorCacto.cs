using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCacto : MonoBehaviour
{

    public GameObject[] cactoPrefabs;
    public float dealyInicial;
    public float delayEntreCactos;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("GerarCacto", dealyInicial, delayEntreCactos);
    }

    // Update is called once per frame
    private void GerarCacto()
    {
        var quantidadeCactos = cactoPrefabs.Length;
        var indiceAleatorio = Random.Range(0, quantidadeCactos);
        var cactoPrefab = cactoPrefabs[indiceAleatorio];
        Instantiate(cactoPrefab, transform.position, Quaternion.identity);
    }
}
