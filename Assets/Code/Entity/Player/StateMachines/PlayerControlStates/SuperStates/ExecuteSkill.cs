﻿using UnityEngine;

namespace Code.Entity.Player.StateMachines.PlayerControlStates.SuperStates
{
  public abstract class ExecuteSkill : PlayerControlState
      {
          public override void OnStateExit() { }
          public override void OnReceiveMovementInput(Vector2 direction) { }
          public override void OnReceiveButtonInput(PlayerControlsStateMachine.InputButton button) { }
  
          public override void OnHoldMovementInput(Vector2 direction) { }
  
          public override void OnHoldButtonInput(PlayerControlsStateMachine.InputButton button) { }
  
          public override void OnReleaseMovementInput() { }
  
          public override void OnReleaseButtonInput(PlayerControlsStateMachine.InputButton button) { }
  
          public override void OnCollisionEnter2D(Collision2D collision) { }
  
          public override void OnCollisionExit2D(Collision2D collision) { }
  
          public override void OnCollisionStay2D(Collision2D collision) { }
          public override void StateUpdate() { }
          public ExecuteSkill(PlayerData data, EntityPhysics entityPhysics, PlayerControlsStateMachine controlsStateMachine) : base(data, entityPhysics, controlsStateMachine) { }
      }
}