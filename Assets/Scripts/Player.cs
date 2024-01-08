using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public InputActionReference move;
    public InputActionReference dash;
    public float speed = 0;
    public Vector3 input;
    public int HP;
    public int Mana;
    public bool invicibilityframes = false;
    private bool candash = true;
    [SerializeField] float dashingstrenght = 5f;
    
    

    private void OnEnable()
    {
        move.action.Enable();
        dash.action.Enable();
        move.action.performed += SetInput;
        move.action.canceled += StopMovement;
        dash.action.performed += Dash;
    }

    private void OnDisable()
    {
        move.action.canceled -= StopMovement;
        dash.action.performed -= Dash;
        move.action.performed -= SetInput;
        move.action.Disable();
        dash.action.Disable();
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