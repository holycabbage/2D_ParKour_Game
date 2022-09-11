using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rd;

    bool isAttack = false; 
   


    void Awake()
    {
        rd = this.GetComponent<Rigidbody2D>(); 
    }

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hero")
        {
            isAttack = true;
        }
        if (collision.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

   
}
