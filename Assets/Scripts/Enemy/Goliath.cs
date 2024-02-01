using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class Goliath : MonoBehaviour,IEnemyinterface
{
    [SerializeField] float Aggrorange;
    Vector2 playerposition;
    Vector2 currentposition;
    GameObject player;
    [SerializeField] public float movementSpeed = 3f;
    [SerializeField] public int HP;
    private bool canmove;
    private  BoxCollider2D boxCollider2D;
    private new Rigidbody2D rigidbody2D;
    private GoliathMeleeAttack goliathMeleeAttack;
    private float distance;
    private Animator animator;
    private Player damagedplayer;
    void Awake()
    {
        animator = GetComponent<Animator>();
        goliathMeleeAttack = GetComponentInChildren<GoliathMeleeAttack>();
        boxCollider2D=GetComponent<BoxCollider2D>();
        canmove=true;
        player = GameObject.FindWithTag("Player");
        rigidbody2D=GetComponent<Rigidbody2D>();
        damagedplayer = GetComponent<Player>();

    }

    void Update()
    {
        if(canmove==true)
        {
        animator.SetFloat("MoveXgoliath", rigidbody2D.velocity.x);
        animator.SetFloat("MoveYgoliath", rigidbody2D.velocity.y);
        }
        playerposition = player.transform.position;
       if(Vector2.Distance(playerposition,(Vector2)transform.position)<=Aggrorange) 
       {
            if (canmove == true)
            {
                goliath(player.transform.position);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        canmove=false;
         if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Player")) {
            player = collision.gameObject;
                damagedplayer=player.GetComponent<Player>();
                damagedplayer.TakeDamage(1);
        }
    
            StartCoroutine(Meleewait());
        

    }

    private void goliath(Vector3 targetPosition)
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
    IEnumerator Meleewait()
    {
        yield return new WaitForSeconds(1);
        canmove=true;
    }
    IEnumerator Death()
    {
        yield return null;
        Destroy(gameObject);
    }
}

