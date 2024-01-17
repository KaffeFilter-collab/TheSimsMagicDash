using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Magicbolt : MonoBehaviour,ISpellInterface
{
   
    static int Mana;
    [SerializeField] private int Manacost;
    [SerializeField] float diffrence;
    Rigidbody2D rigidbody2D;
    public Vector2 mousepositionforspell;
    public magicboltspell spellprefab;
    

        public void Start()
        {
            rigidbody2D=gameObject.GetComponent<Rigidbody2D>();
        }

        public void Update()
       {
        if(transform.parent!=null)transform.localPosition= new Vector3(0,0,0);
       }
        
        public void SpellCasted()
        {
            mousepositionforspell = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            if(Mana >= Manacost){
            Mana=Mana-Manacost;
            Instantiate(spellprefab,rigidbody2D.transform);
            }
        }
        public void casted()
        {
            print("casted");
            SpellCasted();
        }
        void Spell1casted()
        {
            
            print("Hi"+gameObject.GetComponentInParent<Transform>().tag);
            if(gameObject.GetComponentInParent<Transform>().tag == "SpellSlot1")    
            {
            mousepositionforspell = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            print(mousepositionforspell);
            //if(Mana >= Manacost){
            //Mana=Mana-Manacost;
            Instantiate(spellprefab);
            }
            //}
        }
        void Spell2casted()
        {
        if(gameObject.GetComponentInParent<Transform>().tag == "SpellSlot2")
            {
                SpellCasted();
                print("debug");
            }
        }

}
   

