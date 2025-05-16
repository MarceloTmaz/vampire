using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ContarPontos : MonoBehaviour
{
    public TMP_Text placar;
    public int pontos = 0;

    // Start is called before the first frame update
    void Start()
    {
        placar.text = pontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            pontos += 10;
            placar.text = pontos.ToString();
        }
        if (collision.gameObject.layer == 13)
        {
            pontos = 0;
            placar.text = pontos.ToString();
        }
    }
}
