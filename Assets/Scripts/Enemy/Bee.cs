using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //Sprites
    SpriteRenderer spriteRenderer;
    public Sprite exsplosion;
    //OBJ refrences
    GameObject player;
    
    //Setting for Balance
    [SerializeField] public float movementSpeed = 3f;
    [SerializeField] public int HP;
    public bool canmove;
    private  BoxCollider2D boxCollider2D;
    private new Rigidbody2D rigidbody2D;

    private bool isExploding;
    
    void Awake()
    {

        boxCollider2D=GetComponent<BoxCollider2D>();
        canmove=true;
        player = GameObject.FindWithTag("Player");
        rigidbody2D=GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        Bee(player.transform.position);        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        canmove=false;
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Exsplosion());
        }

       
    }
    
    

    private void Bee(Vector3 targetPosition)
    {
        if(canmove==true){
        Vector2 moveDirection =new Vector2(targetPosition.x - transform.position.x,targetPosition.y - transform.position.y);
        moveDirection = moveDirection.normalized;

        rigidbody2D.velocity = moveDirection * movementSpeed;
        }
        else
        {
        rigidbody2D.velocity=new Vector2(0,0);
        }
    }
    IEnumerator Exsplosion()
        {
            
            canmove=false;
            spriteRenderer.sprite = exsplosion; 
            gameObject.transform.localScale =new Vector3(2,2,0);
            boxCollider2D.size = new Vector3(2.3f,2.3f,0);
            yield return new WaitForSeconds(0.5f); 
            isExploding=true;
            yield return new WaitForSeconds(0.5f); 
            

            
           Destroy(gameObject);
        }

    
}
