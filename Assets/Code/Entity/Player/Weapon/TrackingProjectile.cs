using UnityEngine;

namespace Code.Entity.Player.Weapon
{
    public class TrackingProjectile : Projectile
    {
        private Transform _trackedTarget;
        private float _firedSpeed;
        
        private void Update()
        {
            Vector2 newTravelForce = (_trackedTarget.position - transform.position).normalized * _firedSpeed;
            if (_continuousForce != newTravelForce)
            {
                Debug.Log("Changing Direction");
                _entityPhysics.RemoveAllContinuousForces();
                FireProjectile((_trackedTarget.position - transform.position).normalized, _firedSpeed);
            }
        }

        public override void FireProjectile(Vector2 newTravelDirection, float newSpeed)
        {
            base.FireProjectile(newTravelDirection, newSpeed);
            _firedSpeed = newSpeed;
        }

        public void SetTarget(Transform newTarget)
        {
            _trackedTarget = newTarget;
        }
    }
}