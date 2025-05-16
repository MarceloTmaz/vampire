using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anime;

    public float moveSpeed = 5f; // Ajuste a velocidade do movimento
    private Vector3 startDragPosition;
    private bool isDragging = false;
    public Rigidbody2D rb; // Referência ao Rigidbody do jogador (recomendado para física)
    // Ou, se você não usar física, pode usar um CharacterController ou manipular a transform diretamente

    public bool cima = false;
    public bool direita = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody não encontrado neste GameObject. Considere adicionar um.");
        }
    }

    void Update()
    {
        if (rb.bodyType != RigidbodyType2D.Dynamic)
        {
            anime.SetBool("voo", false);
        }
        // Detecta o início do clique
        if (Input.GetMouseButtonDown(0)) // 0 representa o botão esquerdo do mouse
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

            // Move o jogador na direção do arrasto
            MovePlayer(worldDragDirection);
        }
    }

    Vector3 ScreenToWorldDirection(Vector3 screenVector)
    {
        // Remove a componente Z (profundidade da tela)
        screenVector.z = 0;

        // Converte o vetor de pixels da tela para um vetor no mundo
        // Assumindo que o movimento será no plano XY (horizontal)
        Vector3 worldDirection = Camera.main.ScreenToWorldPoint(startDragPosition + screenVector) - Camera.main.ScreenToWorldPoint(startDragPosition);
        worldDirection.z = 0f; // Garante que o movimento seja apenas no plano horizontal
        return worldDirection.normalized; // Normaliza para obter apenas a direção
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
