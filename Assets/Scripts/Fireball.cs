using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Fireball : MonoBehaviour
{
    static int Mana;
    [SerializeField] private int Manacost;
    [SerializeField] float diffrence;
    public Vector2 mousepositionforspell;
    public test spellprefab;
    

        public void OnEnable()
        {
            Player.spell1casted+=Spell1casted;
            Player.spell2casted+=Spell2casted;
           
        }
        public void OnDisable()
        {
            Player.spell1casted-=Spell1casted;
            Player.spell2casted-=Spell2casted;
        }
        public void Update()
       {
        if(transform.parent!=null)transform.localPosition= new Vector3(0,0,0);
       }
        
        public void SpellCasted()
        {
            mousepositionforspell = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //if(Mana >= Manacost){
            //Mana=Mana-Manacost;
            Instantiate(spellprefab);
            //}
        }

        void Spell1casted()
        {
            print("Spellinput is working");
          //  if(gameObject.GetComponentInParent<Transform>().tag == "SpellSlot1")
           // {
            mousepositionforspell = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            print(mousepositionforspell);
            //if(Mana >= Manacost){
            //Mana=Mana-Manacost;
            Instantiate(spellprefab);
            //}
          //  }
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
