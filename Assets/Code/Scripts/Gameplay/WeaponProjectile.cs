using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeaponProjectile : MonoBehaviour
    {
        public WeaponProjectileConfig config;

        private Rigidbody rigidBody;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (rigidBody.velocity.magnitude < config.minimumProjectileVelocityToInflictDamage)
            {
                return;
            }

            if (!collision.collider.CompareTag(config.targetTag))
            {
                return;
            }

            Health health = collision.gameObject.GetComponent<Health>();
            if (health == null)
            {
                return;
            }

            health.TakeDamage(config.damage);
        }
    }
}

