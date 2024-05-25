using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    
    public PlayerMoveState MoveState { get; private set; }
    
    public PlayerIdleState IdleState { get; private set; }


    public Animator Animator { get; private set; }

    [SerializeField] private PlayerData playerData;
    public void Awake()
    {
        Debug.Log(" awake object");
        StateMachine = new PlayerStateMachine();
      
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        
    }

    public void Start()
    {
    //    Animator = GetComponent<Animator>();
        
        // Initialize  starting State as idle data in state machine 
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicUpdate();
    }
}
