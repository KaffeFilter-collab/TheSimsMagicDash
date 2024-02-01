using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Centepied : MonoBehaviour,IEnemyinterface
{
    [SerializeField]int health;
    [SerializeField]int attackBeforeBreak;
    private bool attackstart;
    void Awake(){
        BossStart();
    }
    
    void BossStart()
    {
        
        while(health<0)
        {
            while(attackBeforeBreak>0)
            {
            StartCoroutine(AttackIndicator());
            if(attackstart==false)
            {
                attackstart=true;
                switch (Random.Range(0, 3)) { 
                    case 0:  transform.position=new Vector3(225.45f,22.18f,0);break;
                    case 1: transform.position=new Vector3(244.74f,22.18f,0);break;
                    case 2: transform.position=new Vector3(225.45f,32.77f,0);break;
                    case 3: transform.position=new Vector3(232.36f,34.36f,0);break;
            }
            }
            }
        }
    }
    public void gothit(int damage)
    {
            health=health-damage;
    }
    IEnumerator AttackIndicator()
    {
        yield return new WaitForSeconds(1f);
        attackstart=false;

    }
}
