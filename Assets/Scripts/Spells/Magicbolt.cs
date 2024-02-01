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
    private bool Cancast=true;

        public void Start()
        {
            rigidbody2D=gameObject.GetComponent<Rigidbody2D>();
        }

        public void Update()
       {
        if(transform.parent!=null)transform.localPosition= new Vector3(0,0,8);
       }
        
        public void SpellCasted()
        {
            if(transform.parent!=null)
            {
                if(Cancast==true){
                Instantiate(spellprefab,rigidbody2D.transform);
                transform.DetachChildren();
                StartCoroutine(castdelay());
            }
            }
        }

        public void casted()
        {
            
            SpellCasted();
        }

        IEnumerator castdelay()
        {
            Cancast=false;
            yield return new WaitForSeconds(1);
            Cancast=true;
        }
}
   

