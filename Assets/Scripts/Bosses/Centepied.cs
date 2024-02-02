using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
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
    private Player damagedplayer;
    GameObject player;
    private GameObject screenUI;
    void Awake()
    {
        animator = GetComponent<Animator>();
        cases=1;
        speed=0;
        player = GameObject.FindWithTag("Player");
        damagedplayer = GetComponent<Player>();
        screenUI = GameObject.FindGameObjectWithTag("screenUI");
    }
     private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target, Time.deltaTime * speed);
        }
    public void BossStart()
    {   
    if(cases==1){
            speed=7;
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
            target=new Vector3(232.44f,38.36f,0);
            animator.SetFloat("ValiMovex", 0);
            animator.SetFloat("ValiMoveY", 1);
            StartCoroutine(wait());
                    }
        if(cases==4)
                     {
            transform.position=new Vector3(225.2f,18.34f,0);
            target=new Vector3(225.2f,38.36f,0);
            animator.SetFloat("ValiMovex", 0);
            animator.SetFloat("ValiMoveY", 1);
            StartCoroutine(wait());
                     }
        if(cases>=5){
            target=new Vector3(232.44f,28.05f,0);
            transform.position=new Vector3(232.44f,38.55f,0);
            animator.SetFloat("ValiMovex", 0);
            animator.SetFloat("ValiMoveY", -1);
            cases=0;
            StartCoroutine(wait2());
        }
    
    }
            
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Player")) {
            player = collision.gameObject;
                damagedplayer=player.GetComponent<Player>();
                damagedplayer.TakeDamage(5);
        }
    }
        
    
    public void gothit(int damage)
    {
            health=health-damage;
            if(health<=0)
            {
                 screenUI.transform.GetChild(2).gameObject.SetActive(true);
                Destroy(gameObject);
            }
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);
        cases++;
        BossStart();
    }
     IEnumerator wait2()
    {
        yield return new WaitForSeconds(2);
        target=new Vector3(232.44f,18.05f,0);
        yield return new WaitForSeconds(2);
        cases++;
        BossStart();
    }
   

}