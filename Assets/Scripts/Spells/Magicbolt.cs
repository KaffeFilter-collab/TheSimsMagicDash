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
            
            if(Mana >= Manacost){
            Mana=Mana-Manacost;
            Instantiate(spellprefab,rigidbody2D.transform);
            transform.DetachChildren();
            }
        }

        public void casted()
        {
            print("casted");
            SpellCasted();
        }

}
   

