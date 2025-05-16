using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D rig;
    public float speed;
    //baixo,esquerda, cima, direita
    public bool []pos = { false, false, true, false };

    public float statusAtual = 0f;
    public float delayRotate = 0.2f;
    public float nextRotateTime = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        nextRotateTime = Time.time + delayRotate;

    }

    // Update is called once per frame
    void Update()
    {
        if (pos[0] == true)
        {
            rig.velocity = -Vector2.right * speed;// move para esquerda se estiver no chão
        }
        else if (pos[1] == true)
        {
            rig.velocity = Vector2.up * speed;
        }else if (pos[2] == true)
        {
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            rig.velocity = -Vector2.up * speed;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 && Time.time>nextRotateTime)
        {
            Vector3 v = new Vector3(0, 180, 270);

            Quaternion targetRotation = Quaternion.Euler(v);

            transform.rotation = targetRotation;
            bool []pos2 = { false, false, false, true };
            pos = pos2;
            nextRotateTime = Time.time + delayRotate;
        }
        if (collision.gameObject.layer == 9 && Time.time > nextRotateTime)
        {

            Vector3 v = new Vector3(0, 180, 0);

            Quaternion targetRotation = Quaternion.Euler(v);

            transform.rotation = targetRotation;

            bool []pos2 = { true, false, false, false };
            pos = pos2;
            nextRotateTime = Time.time + delayRotate;

        }
        if (collision.gameObject.layer == 10 && Time.time > nextRotateTime)
        {

            Vector3 v = new Vector3(180, 0, 0);

            Quaternion targetRotation = Quaternion.Euler(v);

            transform.rotation = targetRotation;
            bool []pos2 = { false, false, true, false };
            pos = pos2;
            nextRotateTime = Time.time + delayRotate;

        }

        if (collision.gameObject.layer == 11 && Time.time > nextRotateTime)
        {

            Vector3 v = new Vector3(0, 180, 90);

            Quaternion targetRotation = Quaternion.Euler(v);

            transform.rotation = targetRotation;
            bool []pos2= { false, true, false, false };
            pos = pos2;
            nextRotateTime = Time.time + delayRotate;

        }
    }

}
