using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossdoor : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    public Sprite closeddoor;
    public Centepied centepied;
    public GameObject Vali;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D=GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = false;
        centepied=GetComponent<Centepied>();
        
    }
     void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player")) 
        {
            print("door");
            transform.position=new Vector3(221.2f,28,0);
            rigidbody2D.isKinematic = true;
            spriteRenderer.sprite = closeddoor; 
            centepied=Vali.GetComponent<Centepied>();
            centepied.BossStart();
        }
    }
}
