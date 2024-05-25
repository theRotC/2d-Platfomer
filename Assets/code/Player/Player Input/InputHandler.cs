using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    private Vector2 movement;
    

    // move
    public void onMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    
    // jump 
    public void onjump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
    // dash
    public void ondash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
    
    // attack
    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
    
}
