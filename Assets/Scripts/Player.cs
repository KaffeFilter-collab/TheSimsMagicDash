using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] public float wait;
    Rigidbody2D rigidbody2d;
    //Controles
    public InputActionReference move;
    public InputActionReference dash;
    public InputActionReference spell1;
    public InputActionReference spell2;
    [HideInInspector] public bool inspell;
    GameObject Spell;
    [SerializeField] public float speed = 0;
    public Vector3 input;
    //BasicStats
    [SerializeField] public int HP;
    [SerializeField] static int Mana;
    private bool Invinicibilityframes = false;
    private bool candash = true;
    [SerializeField] float dashingstrenght = 5f;
    [SerializeField] float dashspeed = 5f;
    public delegate void Spell1casted();
    public delegate void Spell2casted();
    public static event Spell1casted spell1casted;
    public static event Spell2casted spell2casted; 
    ISpellInterface spellInterface;
    //Animation
    private Animator animator;

    private void OnEnable()
    {
        spell1.action.Enable();
        spell2.action.Enable();
        move.action.Enable();
        dash.action.Enable();
        move.action.performed += SetInput;
        move.action.canceled += StopMovement;
        dash.action.performed += Dash;
        spell1.action.performed +=Spell1;
        spell2.action.performed +=Spell2;
       


    }

    private void OnDisable()
    {
        spell1.action.canceled-=Spell1;
        spell2.action.canceled-=Spell2;
        move.action.canceled -= StopMovement;
        dash.action.performed -= Dash;
        move.action.performed -= SetInput;
        move.action.Disable();
        dash.action.Disable();  
        spell1.action.Disable();
        spell2.action.Disable();
        
        
    }

    private void Awake()
    {
        Invinicibilityframes=false;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("debugcollisionworks");
        if(collision.gameObject.CompareTag("Enemy"))
        {
          if(Invinicibilityframes==false){
                HP--;
                if(HP<=0)
                {
            print("Hp down");
                }
        }
        }
    }
     public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x, -rigidbody2d.velocity.y);
        }

        if (collision.gameObject.CompareTag("Spell")) {
            print("inspell");
            Spell = collision.gameObject;
            inspell = true;
            print(inspell);
        }
    }
    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Spell")) {
            Spell = collision.gameObject;
            inspell = false;
        }
    }


   

    void Dash(InputAction.CallbackContext ctx)
    {
        print("Hallo");
        if (candash == true)
        {            
            StartCoroutine(DashRoutine(input));
        }


    }

    void StopMovement(InputAction.CallbackContext ctx)
    {
        input = Vector2.zero;
       
    }

    void SetInput(InputAction.CallbackContext ctx)
    {
        input = ctx.ReadValue<Vector2>();
        
        
    }
    void Spell1(InputAction.CallbackContext ctx)
    {
      //  print("buttonworks");
        if(inspell==true && Spell.transform.parent==null){
        transform.GetChild(0).DetachChildren();
        Spell.transform.SetParent(transform.GetChild(0));
        Spell.transform.localPosition = Vector2.zero;
        }
       if(transform.GetChild(0).GetChild(0)!=null){
        ISpellInterface spellInterface = transform.GetChild(0).GetComponentInChildren<ISpellInterface>();
        spellInterface.casted();
       }
        
    }

    void Spell2(InputAction.CallbackContext ctx)
    {
        if(inspell==true && Spell.transform.parent==null){
        transform.GetChild(1).DetachChildren();
        Spell.transform.SetParent(transform.GetChild(1));
        Spell.transform.localPosition = Vector2.zero;
        }
        
        spell2casted?.Invoke();
    }
   



    private void FixedUpdate()
    {
        if (candash == true)
        {
            rigidbody2d.velocity = input * speed;
            if(input.x >= 0.1)
                    {
            animator.SetBool("gehn hoch" , false);
            animator.SetBool("gehn runter" , false);
            animator.SetBool("gehn rechts" , true);                
            animator.SetBool("gehn links" , false);
                     }
        if(input.x <= -0.1)
                    {
            animator.SetBool("gehn hoch" , false);
            animator.SetBool("gehn runter" , false);
            animator.SetBool("gehn rechts" , false);                
            animator.SetBool("gehn links" , true);
                    }
         if(input.y >= 0.1)
                    {
            animator.SetBool("gehn hoch" , false);
            animator.SetBool("gehn runter" , true);
            animator.SetBool("gehn rechts" , false);                
            animator.SetBool("gehn links" , false);
                    }
        if(input.y <= -0.1)
                    {
            animator.SetBool("gehn hoch" , true);
            animator.SetBool("gehn runter" , false);
            animator.SetBool("gehn rechts" , false);                
            animator.SetBool("gehn links" , false);
                    }                       
        }
    }


    
    IEnumerator DashRoutine(Vector2 direction)
    {
        candash = false;
        Invinicibilityframes = true;
        while (candash == false) {
            rigidbody2d.velocity = input * dashspeed;
            dashspeed = dashspeed * dashingstrenght;
            print(dashspeed);
            if (dashspeed <= speed) candash = true;
            yield return new WaitForSeconds(wait);

        }
        rigidbody2d.velocity = new Vector2(0f, 0f);
        Invinicibilityframes = false;
        dashspeed = 10;
        print(dashspeed);
        yield return null;
    }

    
}