using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField] public float wait;
    Rigidbody2D rigidbody2d;
    
    //Sprites
    public enum AttackAnimation
    {
        up,down,left,right
    }
    public AttackAnimation attackanimation;
    public SpriteRenderer spriteRenderer;
    public Sprite attack_up;
    public Sprite attack_down;
    public Sprite attack_left;
    public Sprite attack_right;
    //Controles
    public Meleehit meleehit;
    public InputActionReference move;
    public InputActionReference dash;
    public InputActionReference spell1;
    public InputActionReference spell2;
    [HideInInspector] public bool inspell;
    GameObject Spell;
    [SerializeField] public float speed = 0;
    public Vector3 input;
    
    //BasicStats
    [SerializeField] public int MaxHP;
    [SerializeField] public int HP;
    [SerializeField] static int Mana;
    private bool Invinicibilityframes = false;
    private bool candash = true;
    [SerializeField] float dashingstrenght = 5f;
    [SerializeField] float dashspeed = 5f;
    ISpellInterface spellInterface;
    
    //Animation
    private Animator animator;
    [HideInInspector]
    private GameObject screenUI;
    [SerializeField]


    private void OnEnable()
    {
        spell1.action.Enable();
        spell2.action.Enable();
        move.action.Enable();
        dash.action.Enable();
        move.action.performed += SetInput;
        move.action.canceled += StopMovement;
        dash.action.performed += Dash;
        spell1.action.performed += Spell1;
        spell2.action.performed += Spell2;
    }

    private void OnDisable()
    {
        spell1.action.canceled -= Spell1;
        spell2.action.canceled -= Spell2;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        meleehit = GetComponentInChildren<Meleehit>();
        Invinicibilityframes = false;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        screenUI = GameObject.FindGameObjectWithTag("screenUI");
        screenUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Health: " + HP.ToString();
    }   
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Invinicibilityframes == false) {
                HP--;
                if (HP <= 0)
                {
                    print("Hp down");
                }
            }
        }
        if (collision.gameObject.CompareTag("Wall")) 
        {
            input = Vector2.zero;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Wall")) {
            rigidbody2d.velocity = new Vector2(-rigidbody2d.velocity.x, -rigidbody2d.velocity.y);
        }

        if (collision.gameObject.CompareTag("Spell")) {
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
        if (inspell == true && Spell.transform.parent == null) {
            transform.GetChild(0).DetachChildren();
            Spell.transform.SetParent(transform.GetChild(0));
            Spell.transform.localPosition = Vector2.zero;
        }
        if (transform.GetChild(0).GetChild(0) != null) {
            ISpellInterface spellInterface = transform.GetChild(0).GetComponentInChildren<ISpellInterface>();
            spellInterface.casted();
        }

    }
     void Spell2(InputAction.CallbackContext ctx)
    {
        if (inspell == true && Spell.transform.parent == null) {
            transform.GetChild(1).DetachChildren();
            Spell.transform.SetParent(transform.GetChild(1));
            Spell.transform.localPosition = Vector2.zero;
        }
        if (transform.GetChild(1).GetChild(0) != null) {
            ISpellInterface spellInterface = transform.GetChild(1).GetComponentInChildren<ISpellInterface>();
            spellInterface.casted();
        }
    }
   


        void Update()
        {
        animator.SetFloat("MoveX", input.x);
        animator.SetFloat("MoveY", input.y);
           
        }

        void FixedUpdate()
        {
        
        
            if (candash == true)
            {
                if (input.y != 0)
                {
                    rigidbody2d.velocity = input * new Vector2(0, 1) * speed;
                }
                if (input.x != 0)
                {
                    rigidbody2d.velocity = input * new Vector2(1, 0) * speed;
                }
                if (input.y == 0f && input.x == 0f)
                {
                    rigidbody2d.velocity = new Vector2(0, 0);
                }

            
        }
       
        }

        public void TakeDamage(int damage)
        {
            if(Invinicibilityframes==false){
                HP=HP-damage;
                screenUI.transform.GetChild(0).GetComponent<TMP_Text>().text = "Health: " + HP.ToString();
                if(HP<=0)
                {
                    screenUI.transform.GetChild(1).gameObject.SetActive(true);
                    candash=false;
                    speed=0;
                    rigidbody2d.velocity=Vector2.zero;
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
            
                if (dashspeed <= speed) candash = true;
                yield return new WaitForSeconds(wait);

            }
            rigidbody2d.velocity = new Vector2(0f, 0f);
            Invinicibilityframes = false;
            dashspeed = 10;
            
            yield return null;
        }

        IEnumerator AttackAnimationCorrotine()
        {
            switch(attackanimation)
            {
                case AttackAnimation.up:
                spriteRenderer.sprite=attack_up;
                break;
                case AttackAnimation.down:
                spriteRenderer.sprite=attack_down;
                break;
                case AttackAnimation.left:
                spriteRenderer.sprite=attack_left;
                break;
                case AttackAnimation.right:
                spriteRenderer.sprite=attack_right;
                break;
            }
            yield return new WaitForSeconds(0.5f);
        animator.StartPlayback();
            
        }

    }
