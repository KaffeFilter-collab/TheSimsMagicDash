using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goliath : MonoBehaviour
{
    Vector2 playerposition;
    GameObject player;
    [SerializeField] public float movementSpeed = 3f;
    [SerializeField] public int HP;
    public bool canmove;
    private  BoxCollider2D boxCollider2D;
    private new Rigidbody2D rigidbody2D;
    private Enemy enemy;
    public GoliathMeleeAttack goliathMeleeAttack;
    void Awake()
    {
        goliathMeleeAttack = GetComponentInChildren<GoliathMeleeAttack>();
        boxCollider2D=GetComponent<BoxCollider2D>();
        canmove=true;
        player = GameObject.FindWithTag("Player");
        rigidbody2D=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(canmove==true)
        {
        goliath(player.transform.position);        
        }
        if(canmove==false)
        {
            rigidbody2D.velocity=new Vector2(0,0);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerposition=player.transform.position;
        if (playerposition.x >= 0.1)
        {
            goliathMeleeAttack.attackdirection = GoliathMeleeAttack.Attackdirection.right;
        }
        if (playerposition.x <= -0.1)
        {
            goliathMeleeAttack.attackdirection = GoliathMeleeAttack.Attackdirection.left;
        }
        if (playerposition.y >= 0.1)
        {
            goliathMeleeAttack.attackdirection = GoliathMeleeAttack.Attackdirection.up;
        }
        if (playerposition.y <= -0.1)
        {
            goliathMeleeAttack.attackdirection = GoliathMeleeAttack.Attackdirection.down;
        }

        if(collision.gameObject.CompareTag("Player") && canmove==true)
        {
            goliathMeleeAttack.Attack();
            canmove=false;
            StartCoroutine(Meleewait());
        }

       
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

    IEnumerator Meleewait()
    {
        yield return new WaitForSeconds(1);
        canmove=true;
    }
}

