using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public InputActionReference move;
    public InputActionReference dash;
    public InputActionReference castspell1;
    public InputActionReference castspell2;
    [SerializeField] public float speed = 0;
    public Vector3 input;
    [SerializeField] public int HP;
    [SerializeField] public int Mana;
    public bool invicibilityframes = false;
    private bool candash = true;
    [SerializeField] float dashingstrenght = 5f;
    
    

    private void OnEnable()
    {
        castspell1.action.Enable();
        castspell2.action.Enable();
        move.action.Enable();
        dash.action.Enable();
        move.action.performed += SetInput;
        move.action.canceled += StopMovement;
        dash.action.performed += Dash;
        castspell1.action.performed += SpellCast1;
        castspell2.action.performed += SpellCast2;

    }

    private void OnDisable()
    {
        move.action.canceled -= StopMovement;
        dash.action.performed -= Dash;
        move.action.performed -= SetInput;
        castspell1.action.performed -= SpellCast1;
        castspell1.action.performed -= SpellCast1;
        move.action.Disable();
        dash.action.Disable();
        castspell1.action.Disable();
        castspell2.action.Disable();
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
   void SpellCast1(InputAction.CallbackContext ctx)
    {
        print("spell1");
    }
    void SpellCast2(InputAction.CallbackContext ctx)
    {
        print("spell2");
    }

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        rigidbody2d.velocity = input * speed;
    } 

    IEnumerator DashRoutine(Vector2 direction)
    {
        candash = false;
        invicibilityframes = true;
        rigidbody2d.MovePosition(transform.position + input*dashingstrenght);
        yield return null;            
        rigidbody2d.velocity= new Vector2(0f,0f);
        candash=true;
        invicibilityframes=false;
        print("aftercorutine");

    }
    
}