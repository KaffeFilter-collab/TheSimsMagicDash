using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public InputActionReference move;
    public InputActionReference dash;
    public float speed = 0;
    public Vector2 input;
    public int HP;
    public int Mana;
    public bool invicibilityframes = false;
    private bool candash = true;
    private float dashingstrenght = 3;
    private float dashtime = 1;
    

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
            StartCoroutine(DashRoutine());
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

    IEnumerator DashRoutine()
    {
        candash = false;
        invicibilityframes = true;
        rigidbody2d.velocity = new Vector2(transform.localScale.x *dashingstrenght, 0f);
        yield return  new WaitForSeconds(dashtime);
    }
    
}