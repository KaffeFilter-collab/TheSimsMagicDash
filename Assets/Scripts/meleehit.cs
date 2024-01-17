using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleehit: MonoBehaviour
{
    public enum Attackdirection
    {
        left,right
    }

    public Attackdirection attackdirection;
    new Vector2 AttackOffset;
    Collider2D Meleecollider;

    private void Awake()
    {
        Meleecollider=GetComponent<Collider2D>();
        AttackOffset = transform.position;
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
        }
    }
    
    
    
    private void AttackRight()
    {
        Meleecollider.enabled=true;
        transform.position=AttackOffset*-1;

    }
    private void AttackLeft()
    {
        Meleecollider.enabled=true;
        transform.position=AttackOffset;
    }
    public void StopAttack()
    {
        Meleecollider.enabled=false;

    }
}
