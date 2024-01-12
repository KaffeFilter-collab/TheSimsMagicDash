
using UnityEngine;
using UnityEngine.InputSystem;


public class gridtest : MonoBehaviour
{
    public InputActionReference Griddebugging;
    private Grid grid;
    new Vector2 mousePosition;
    private new Vector3 mousepositionchanger;

    private void OnEnable()
    {
        Griddebugging.action.Enable();
        Griddebugging.action.performed += griddebugginh;
    }

    private void OnDisable()
    {
        Griddebugging.action.Disable();
        Griddebugging.action.performed -= griddebugginh;
    }




    void griddebugginh(InputAction.CallbackContext ctx)
    {
        print("mouseinputisworking");
        mousepositionchanger = mousePosition;
        grid.SetValue(mousepositionchanger,56);
    }

    void Start()
    {
        
        grid = new Grid(20, 10,10f,transform);
    }


    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
    }
    

}
