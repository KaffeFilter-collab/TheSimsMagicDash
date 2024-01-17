using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class magicboltspell : MonoBehaviour
{
    private Vector3 mouseposition;
    public Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
        mouseposition=Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = mouseposition-transform.position;
        Vector3 rotation = transform.position-mouseposition;
        rigidbody2D.velocity= new Vector2(direction.x,direction.y).normalized*2;
        
    }
}
