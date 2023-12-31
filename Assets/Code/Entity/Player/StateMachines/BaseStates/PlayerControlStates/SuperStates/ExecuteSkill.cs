﻿using System;
using UnityEngine;

namespace Code.Entity.Player.StateMachines.BaseStates.PlayerControlStates.SuperStates
{
    public abstract class ExecuteSkill : PlayerControlState
    {
        protected float m_maxCooldown;
        protected float m_timeWhenAvailable;
        private PlayerControlsStateMachine.AttackHaltHandle _haltHandle;

        public ExecuteSkill(PlayerData data, EntityPhysics entityPhysics, PlayerControlsStateMachine controlsStateMachine, float cooldown) : base(data, entityPhysics, controlsStateMachine)
        {
            m_maxCooldown = cooldown;
            m_timeWhenAvailable = 0;
        }

        public override void OnStateEnter()
        {
            _haltHandle = m_controlsStateMachine.HaltAutoAttacks();
        }

        public override void OnStateExit()
        {
            m_timeWhenAvailable = m_maxCooldown + Time.time;
            m_controlsStateMachine.ReleaseAutoAttackHaltHandle(_haltHandle);
        }

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

        public bool IsSkillReady()
        {
            return Time.time >= m_timeWhenAvailable;
        }

        public float GetTimeRemainingUntilReady()
        {
            return Math.Max(m_timeWhenAvailable - Time.time, 0);
        }

        public float GetPercentCooldownCompleted()
        {
            return GetTimeRemainingUntilReady() / m_maxCooldown;
        }

        public void ReduceCooldown(float reductionTime)
        {
            m_timeWhenAvailable = MathF.Min(m_timeWhenAvailable - reductionTime, Time.time);
        }

        public void SetMaxCooldown(float newMaxCooldown)
        {
            m_maxCooldown = newMaxCooldown;
        }
    }
}