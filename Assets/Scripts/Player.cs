using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] public float wait;
    Rigidbody2D rigidbody2d;
    public InputActionReference move;
    public InputActionReference dash;
   
    [SerializeField] public float speed = 0;
    private Vector3 input;
    [SerializeField] public int HP;
    [SerializeField] public int Mana;
    private bool Invinicibilityframes = false;
    private bool candash = true;
    [SerializeField] float dashingstrenght = 5f;
    [SerializeField] float dashspeed = 5f;


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
        if (candash == true)
        {
            rigidbody2d.velocity = input * speed;
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
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            if (dashspeed <= speed) candash = true;
            yield return new WaitForSeconds(wait);

        }
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        rigidbody2d.velocity = new Vector2(0f, 0f);
        Invinicibilityframes = false;
        
        dashspeed = 10;
        print(dashspeed);
        yield return null;
    }

}