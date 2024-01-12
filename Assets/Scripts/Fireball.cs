using UnityEngine;
using UnityEngine.InputSystem;

public class Fireball : MonoBehaviour
{
    [SerializeField] float diffrence;
    public InputActionReference spellcast1;
    public InputActionReference spellcast2;

    private void OnEnable()
    {

        spellcast1.action.Enable();
        spellcast2.action.Enable();
        spellcast1.action.performed += spell1;
        spellcast2.action.performed += spell2;
    }
    private void OnDisable()
    {
        
        spellcast1.action.performed -= spell1;
        spellcast2.action.performed -= spell2;
        spellcast1.action.Disable();
        spellcast2.action.Disable();
    }

    void spell1(InputAction.CallbackContext ctx)
        {
        
        if (transform.parent != null)
        {

            print(diffrence);
        }
    }

    void spell2(InputAction.CallbackContext ctx) 
        {
        
        if (transform.parent != null)
        {
            print("bla bla");
        }
    }
      public void OnTriggerEnter2D(Collider2D collision) 
      {
        if (collision.gameObject.CompareTag("Player"))
        {
        print("hi");
        
        }
    }
}
