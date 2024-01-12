using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite walking1;
    public Sprite walking2;
    
    [SerializeField] public float wait;
    Rigidbody2D rigidbody2d;
    //Movment
    public InputActionReference move;
    public InputActionReference dash;
    public InputActionReference playermelee;
    private bool ismoving;
   
    [SerializeField] public float speed = 0;
    private Vector3 input;
    //BasicStats
    [SerializeField] public int HP;
    [SerializeField] public int Mana;
    private bool Invinicibilityframes = false;
    private bool candash = true;
    [SerializeField] float dashingstrenght = 5f;
    [SerializeField] float dashspeed = 5f;


    private void OnEnable()
    {
        playermelee.action.Enable();
        move.action.Enable();
        dash.action.Enable();
        move.action.performed += SetInput;
        move.action.canceled += StopMovement;
        dash.action.performed += Dash;
        playermelee.action.performed += PlayerMelee;


    }

    private void OnDisable()
    {
        playermelee.action.performed -= PlayerMelee;
        move.action.canceled -= StopMovement;
        dash.action.performed -= Dash;
        move.action.performed -= SetInput;
        move.action.Disable();
        dash.action.Disable();  
        playermelee.action.Disable();
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("debugcollisionworks");
        if(collision.gameObject.CompareTag("BeeAOE"))
        {
            print("HP");
            HP--;
        }
    }


    void PlayerMelee(InputAction.CallbackContext ctw)
    {
        print("Mele");
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
        ismoving = false;
    }

    void SetInput(InputAction.CallbackContext ctx)
    {
        input = ctx.ReadValue<Vector2>();
        ismoving = true;
    }
   

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (candash == true)
        {
            rigidbody2d.velocity = input * speed;
            
            if(ismoving==true)
            {    
            StartCoroutine(Walkanimationcycle());
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

    IEnumerator Walkanimationcycle()
    {
        while (ismoving==true)
        {     
        spriteRenderer.sprite = walking1; 
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.sprite = walking2; 
        }
    }
}