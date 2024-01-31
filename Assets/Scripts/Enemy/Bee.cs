using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class NewBehaviourScript : MonoBehaviour,IEnemyinterface
{
    //OBJ refrences
    GameObject player;
    
    //Setting for Balance
    [SerializeField] public float movementSpeed = 3f;
    [SerializeField] public int HP;
    public bool canmove;
    private  BoxCollider2D boxCollider2D;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider2D=GetComponent<BoxCollider2D>();
        canmove=true;
        player = GameObject.FindWithTag("Player");
        rigidbody2D=GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        animator.SetFloat("MoveXBee", rigidbody2D.velocity.x);
        animator.SetFloat("MoveYBee", rigidbody2D.velocity.y);
        Bee(player.transform.position);        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
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
    public void gothit(int damage)
    {
            HP=HP-damage;
            print(HP);
            if(HP<=0)
            {
               StartCoroutine(Death());
            }
    }
    IEnumerator Death()
    {
        yield return null;
        Destroy(gameObject);
    
    }
    IEnumerator Exsplosion()
        {
            
            canmove=false;
            animator.SetBool("isExploding",true);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale =new Vector3(1.01f,1.01f,0);
            boxCollider2D.size = new Vector3(1.01f,1.01f,0);
            yield return new WaitForSeconds(1); 
            
            

            
           Destroy(gameObject);
        }

    
}
