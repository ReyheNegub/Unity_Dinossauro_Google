using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentar : MonoBehaviour
{
    public Vector2 direcao;

    public float velocidade;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }
}
