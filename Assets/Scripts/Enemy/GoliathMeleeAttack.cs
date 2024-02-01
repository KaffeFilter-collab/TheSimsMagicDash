using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoliathMeleeAttack : MonoBehaviour
{
    public enum Attackdirection
    {
        left,right,up,down
    }
    private Player player;
    public Attackdirection attackdirection;
    Vector2 AttackOffset;
    public Vector2 AttackOffsety;
    Collider2D Meleecollider;
    private bool canattack;
    private void Awake()
    {
        player = GetComponent<Player>();
        canattack = true;
        Meleecollider=GetComponent<Collider2D>();
        AttackOffset = transform.localPosition*2.5f;
        AttackOffsety = new Vector2(transform.localPosition.x * 0,(transform.localPosition.y +1 )* 3.5f);
    }
    
    public void Attack()
    {
        switch(attackdirection){
            case Attackdirection.left:
                AttackLeft();
                break;
            case Attackdirection.right:
                AttackRight();
                break;
            case Attackdirection.down:
                AttackDown();
                break;
            case Attackdirection.up:
                AttackUp();
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Player")) {
            player.TakeDamage(2);
        }
    }

    private void AttackUp()
    {
        if (canattack)
        {
            canattack = false;
            Meleecollider.enabled = true;
            transform.localPosition = AttackOffsety ;
            print((transform.localPosition));
            StartCoroutine(hitend());
        }
    }
    private void AttackDown()
    {
        if (canattack)
        {
            canattack = false;
            Meleecollider.enabled = true;
            transform.localPosition = AttackOffsety * -1;
            print((transform.localPosition));
            StartCoroutine(hitend());
        }
    }

    private void AttackRight()
    {
        if (canattack)
        {
            canattack = false;
            Meleecollider.enabled = true;
            transform.localPosition = AttackOffset * -1;
            print((transform.localPosition));
            StartCoroutine(hitend());
        }
    }
    private void AttackLeft()
    {
        if (canattack)
        {
            canattack = false;
        print("attack");
        Meleecollider.enabled=true;
        transform.localPosition=AttackOffset;
        print((transform.localPosition));
        StartCoroutine(hitend());
    }
        }

    public void StopAttack()
    {
        Meleecollider.enabled=false;
        
    }

    IEnumerator hitend()
    {
        
        yield return new WaitForSeconds(1f);
        StopAttack();
        canattack = true;
        print("goliath yes");
    }
}
