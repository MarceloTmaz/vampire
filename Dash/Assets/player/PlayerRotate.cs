using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.virarvampiro();
        if (collision.gameObject.layer == 8 )
        {
            if (player.cima)
            {
               Vector3 v = new Vector3 (0, 0, 90);
                // Converte o Vector3 (ângulos de Euler) para um Quaternion
                Quaternion targetRotation = Quaternion.Euler(v);

                // Aplica a rotação ao GameObject
                transform.rotation = targetRotation;

                // Deixa o personagem estatico 
                player.rb.bodyType = RigidbodyType2D.Static;

            }
            else
            {
                Vector3 v = new Vector3(0, 180, 270);

                Quaternion targetRotation = Quaternion.Euler(v);

                transform.rotation = targetRotation;

                player.rb.bodyType = RigidbodyType2D.Static;
            }
        }
        if (collision.gameObject.layer == 9)
        {
            if (player.direita)
            {
                
                Vector3 v = new Vector3(0, 0, 0);

                Quaternion targetRotation = Quaternion.Euler(v);

                transform.rotation = targetRotation;

                player.rb.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                Vector3 v = new Vector3(0, 180, 0);

                Quaternion targetRotation = Quaternion.Euler(v);

                transform.rotation = targetRotation;

                player.rb.bodyType = RigidbodyType2D.Static;
            }
        }
        if (collision.gameObject.layer == 10)
        {
            if (player.direita)
            {
                Vector3 v = new Vector3(180, 0, 0);

                Quaternion targetRotation = Quaternion.Euler(v);

                transform.rotation = targetRotation;

                player.rb.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                Vector3 v = new Vector3(180, 180, 0);

                Quaternion targetRotation = Quaternion.Euler(v);

                transform.rotation = targetRotation;

                player.rb.bodyType = RigidbodyType2D.Static;
            }
        }
        if (collision.gameObject.layer == 11)
        {
            if (player.cima==false)
            {
                Vector3 v = new Vector3(0, 0, 270);

                Quaternion targetRotation = Quaternion.Euler(v);

                transform.rotation = targetRotation;

                player.rb.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                Vector3 v = new Vector3(0, 180, 90);

                Quaternion targetRotation = Quaternion.Euler(v);

                transform.rotation = targetRotation;

                player.rb.bodyType= RigidbodyType2D.Static;

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player.rb.bodyType = RigidbodyType2D.Dynamic;
    }

}
