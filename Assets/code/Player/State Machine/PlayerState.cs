using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
   protected Player player;
   protected PlayerStateMachine StateMachine;
   protected PlayerData playerData;

   protected float startTime;

   private string animBoolName;

   public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData,  string animBoolName)
   {
      this.player = player;
      this.StateMachine = stateMachine;
      this.playerData = playerData;
      this.animBoolName = animBoolName;
   }


   public virtual void Enter()
   {
      DoCheck();
      //player.Animator.SetBool(animBoolName, true);
      startTime = Time.time;
      Debug.Log(animBoolName);
   }

   public virtual void Exit()
   {
      player.Animator.SetBool(animBoolName, false);
   }

   public virtual void LogicUpdate() { }

   public virtual void PhysicUpdate()
   {
   DoCheck();
   }
   
   public virtual void DoCheck() { }
}


