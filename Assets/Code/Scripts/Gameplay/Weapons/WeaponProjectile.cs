using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeaponProjectile : MonoBehaviour
    {
        public WeaponProjectileConfig typeConfig;

        private Rigidbody rigidBody;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            Destroy(gameObject, typeConfig.generalConfig.lifetime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (rigidBody.velocity.magnitude < typeConfig.minimumProjectileVelocityToInflictDamage)
            {
                return;
            }

            if (!collision.collider.CompareTag(typeConfig.targetTag))
            {
                return;
            }

            Health health = collision.gameObject.GetComponent<Health>();
            if (health == null)
            {
                return;
            }

            health.TakeDamage(typeConfig.damage);
        }
    }
}

