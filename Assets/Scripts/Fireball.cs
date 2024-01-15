using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fireball : MonoBehaviour
{

    static int Mana;
    [SerializeField] private int Manacost;
    [SerializeField] float diffrence;
    public Vector2 mousepositionforspell;
    public test spellprefab;
    
   
           
        public void Update()
       {
        if(transform.parent!=null)transform.localPosition= new Vector3(0,0,0);
       }
        
        public void SpellCasted()
        {
            mousepositionforspell = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            if(Mana >= Manacost){
            Mana=Mana-Manacost;
            Instantiate(spellprefab);
            }

        }

}
