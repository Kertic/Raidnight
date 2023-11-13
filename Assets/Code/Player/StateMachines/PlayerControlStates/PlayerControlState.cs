using Code.Player.States;
using UnityEngine;

namespace Code.Player.StateMachines.PlayerControlStates
{
    public abstract class PlayerControlState : IState
    {
        protected PlayerData m_data;
        protected PlayerPhysics m_playerPhysics;
        protected PlayerControlsStateMachine m_controlsStateMachine;

        public PlayerControlState(PlayerData data, PlayerPhysics playerPhysics, PlayerControlsStateMachine controlsStateMachine)
        {
            m_data = data;
            m_playerPhysics = playerPhysics;
            m_controlsStateMachine = controlsStateMachine;
        }

        public override void OnStateEnter()
        {
            Debug.Log("Entered:" + this.GetType().Name);
        }

        public abstract void OnReceiveMovementInput(Vector2 direction);
        public abstract void OnReceiveButtonInput(PlayerControlsStateMachine.InputButton button);
        public abstract void OnHoldMovementInput(Vector2 direction);
        public abstract void OnHoldButtonInput(PlayerControlsStateMachine.InputButton button);
        public abstract void OnReleaseMovementInput();
        public abstract void OnReleaseButtonInput(PlayerControlsStateMachine.InputButton button);

        public abstract void OnCollisionEnter2D(Collision2D collision);
        public abstract void OnCollisionExit2D(Collision2D collision);
        public abstract void OnCollisionStay2D(Collision2D collision);
    }
}