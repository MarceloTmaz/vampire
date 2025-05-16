using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anime;

    public float moveSpeed = 5f; // Ajuste a velocidade do movimento
    private Vector3 startDragPosition;
    private bool isDragging = false;
    public Rigidbody2D rb; // Refer�ncia ao Rigidbody do jogador (recomendado para f�sica)
    // Ou, se voc� n�o usar f�sica, pode usar um CharacterController ou manipular a transform diretamente

    public bool cima = false;
    public bool direita = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody n�o encontrado neste GameObject. Considere adicionar um.");
        }
    }

    void Update()
    {
        if (rb.bodyType != RigidbodyType2D.Dynamic)
        {
            anime.SetBool("voo", false);
        }
        // Detecta o in�cio do clique
        if (Input.GetMouseButtonDown(0)) // 0 representa o bot�o esquerdo do mouse
        {
            startDragPosition = Input.mousePosition;
            isDragging = true;
        }

        // Detecta o fim do clique (o "arrastar" em si acontece entre o Down e o Up)
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            Vector3 endDragPosition = Input.mousePosition;
            Vector3 dragVector = endDragPosition - startDragPosition;

            // Converte o vetor de tela para um vetor no mundo (plano horizontal)
            Vector3 worldDragDirection = ScreenToWorldDirection(dragVector);

            // Move o jogador na dire��o do arrasto
            MovePlayer(worldDragDirection);
        }
    }

    Vector3 ScreenToWorldDirection(Vector3 screenVector)
    {
        // Remove a componente Z (profundidade da tela)
        screenVector.z = 0;

        // Converte o vetor de pixels da tela para um vetor no mundo
        // Assumindo que o movimento ser� no plano XY (horizontal)
        Vector3 worldDirection = Camera.main.ScreenToWorldPoint(startDragPosition + screenVector) - Camera.main.ScreenToWorldPoint(startDragPosition);
        worldDirection.z = 0f; // Garante que o movimento seja apenas no plano horizontal
        return worldDirection.normalized; // Normaliza para obter apenas a dire��o
    }

    void MovePlayer(Vector3 direction)
    {
        // voltar o rigibody para dynamic
        rb.bodyType = RigidbodyType2D.Dynamic;
        if (direction.y > 0)
        {
            cima = true;
        }
        else
        {
            cima = false;
        }

        if (direction.x > 0)
        {
            direita = true;
        }
        else
        {
            direita = false;
        }
        anime.SetBool("chao", false);
        anime.SetBool("voo", true);
        rb.velocity = direction * moveSpeed; // Aplica velocidade ao Rigidbody
    }

    public void virarvampiro()
    {
        anime.SetBool("chao", true);

    }
}
