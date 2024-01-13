using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class meleehit : MonoBehaviour
{

private Vector2 mousePositirionforMeleehit;
public InputActionReference playermelee;

private void OnEnable()
    {
        playermelee.action.Enable();
        playermelee.action.performed += PlayerMelee;
    }

    private void OnDisable()
    {
        playermelee.action.performed -= PlayerMelee;
        playermelee.action.Disable();
        
    }
     void PlayerMelee(InputAction.CallbackContext ctw)
    {
        mousePositirionforMeleehit = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        print("Mele");
        print(mousePositirionforMeleehit);
        
    }
   

}
