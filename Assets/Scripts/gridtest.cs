using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gridtest : MonoBehaviour
{
    new Vector3 mousePosition;
    void Start()
    {
        Grid grid = new Grid(20, 10,10f,transform);
    }

   //public void MousePosition() 
    //{
      //  mousePosition = mainCam.ScreenToWorldPoint(Mouse.current.position);
    //}

}
