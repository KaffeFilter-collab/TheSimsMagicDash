using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class magicboltspell : MonoBehaviour
{
    public IEnemyinterface Ienemyinterface;
    private Vector3 mouseposition;
    public new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        mouseposition=Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = mouseposition-transform.position;
        Vector3 rotation = transform.position-mouseposition;
        rigidbody2D.velocity= new Vector2(direction.x,direction.y).normalized*2;
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Enemy")) 
        {
            
            Ienemyinterface=collision.gameObject.GetComponent<IEnemyinterface>();
            Ienemyinterface.gothit(5);
        }
    }
}
