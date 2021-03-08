using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forcaPulo = 700;

    private bool estaNoChao;

    private float pontos;

    public float multiplicadorPontos = 1;

    public float distanciaMinimaChao = 1;

    public LayerMask layerChao;

    public Text pontosText;

    public Animator animatorComponent;

    // Update is called once per frame
    void Update()
    {
        pontos += Time.deltaTime * multiplicadorPontos;
        pontosText.text = $"Pontos: {Mathf.FloorToInt(pontos)}";

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Abaixar();
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Levantar();
        }
    }

    void Pular()
    {
        if (estaNoChao)
        {
            rb.AddForce(Vector2.up * forcaPulo);
        }
    }

    void Abaixar()
    {
        animatorComponent.SetBool("Abaixado", true);
    }
    void Levantar()
    {
        animatorComponent.SetBool("Abaixado", false);
    }

    private void FixedUpdate()
    {
        estaNoChao = Physics2D.Raycast(transform.position, Vector2.down, distanciaMinimaChao, layerChao);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
