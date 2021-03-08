using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCacto : MonoBehaviour
{

    public GameObject cactoPrefab;
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
        Instantiate(cactoPrefab, transform.position, Quaternion.identity);
    }
}
