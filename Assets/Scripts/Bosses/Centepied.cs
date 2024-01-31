using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using UnityEngine;

public class Centepied : MonoBehaviour,IEnemyinterface
{
    [SerializeField]int health;
    [SerializeField]int attackBeforeBreak;
    private bool attackstart;

    void BossStart()
    {
        StartCoroutine(AttackIndicator());
        if(attackstart==false)
        {
            attackstart=true;

            
        }
    }
    public void gothit(int damage)
    {
            health=health-damage;
            print(health);
            if(health<=0)
            {
               StartCoroutine(Death());
            }
    }
    IEnumerator Death()
    {
        yield return null;
        Destroy(gameObject);
    
    }
    IEnumerator AttackIndicator()
    {
        yield return new WaitForSeconds(1f);
        attackstart=false;

    }
}
