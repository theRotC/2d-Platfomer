
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine  
{
   public PlayerState CurrentState { get; private set; }

   public void Initialize(PlayerState startingState)
   {
      CurrentState = startingState;
      CurrentState.Enter();
  
   }

   public void ChangeState(PlayerState newState)
   {
      // Exit State 
      CurrentState.Exit();
      
      // set new state 
      CurrentState = newState;
      
      // Enter new state 
      CurrentState.Enter();
   }
}
