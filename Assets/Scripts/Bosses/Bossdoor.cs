using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossdoor : MonoBehaviour
{
    Rigidbody2D rigidbody2D;


    private void Awake()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        rigidbody2D.disabled = true;
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Player")) 
        {
        rigidbody2D.enabled = true;
        
            
        }
    }
}
