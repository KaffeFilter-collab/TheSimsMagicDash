using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Centepied : MonoBehaviour,IEnemyinterface
{
    [SerializeField]int health;
    [SerializeField]int attackBeforeBreak;
    private bool attackstart;
    private int cases;
    private Animator animator;
    private bool isattacking;
    new Vector3 target;
    new int speed;
    void Awake()
    {
        animator = GetComponent<Animator>();
        cases=1;
        speed=0;
    }
     private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target, Time.deltaTime * speed);
        }
    void BossStart()
    {   
    if(cases==1){
            speed=2;
            target=new Vector3(232.44f,18.05f,0);
            transform.position=new Vector3(232.44f,38.55f,0);
            animator.SetFloat("ValiMovex", 0);
            animator.SetFloat("ValiMoveY", -1);
            StartCoroutine(wait());
            print(cases);
             }
        if(cases==2)
                    {
            transform.position=new Vector3(248.55f,32.79f,0);
            target=new Vector3(214.31f,32.79f,0);
            animator.SetFloat("ValiMovex", -1);
            animator.SetFloat("ValiMoveY", 0);
            StartCoroutine(wait());
                    }
        if(cases==3)
                    {
            transform.position=new Vector3(232.23f,18.34f,0);
            target=new Vector3(232.44f,18.05f,0);
            animator.SetFloat("ValiMovex", 0);
            animator.SetFloat("ValiMoveY", 1);
            StartCoroutine(wait());
                    }
        if(cases==4)
                     {
            transform.position=new Vector3(225.2f,18.34f,0);
            target=new Vector3(232.44f,18.05f,0);
            animator.SetFloat("ValiMovex", 0);
            animator.SetFloat("ValiMoveY", 1);
            StartCoroutine(wait());
                     }
    
    }
            
            
        
    
    public void gothit(int damage)
    {
            health=health-damage;
            if(health<=0)
            {
                StartCoroutine(death());
            }
    }
    IEnumerator death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        cases++;
        BossStart();
    }
   

}