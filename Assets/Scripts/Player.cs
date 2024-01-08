using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public InputActionReference move;
    public InputActionReference debug;
    public float speed = 0;
    public Vector2 input;
    public int HP;
    public int Mana;

    private void OnEnable()
    {
        move.action.Enable();
        debug.action.Enable();
        move.action.performed += SetInput;
        move.action.canceled += StopMovement;
        debug.action.performed += Debug;
    }

    private void OnDisable()
    {
        move.action.canceled -= StopMovement;
        debug.action.performed -= Debug;
        move.action.performed -= SetInput;
        move.action.Disable();
        debug.action.Disable();
    }

    void Debug(InputAction.CallbackContext ctx)
    {
        print("Hallo");
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
    IEnumerator Wait()
    {
        yield return null;
    }
}