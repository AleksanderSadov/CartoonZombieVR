using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class WeaponProjectile : MonoBehaviour
    {
        public WeaponProjectileConfig config;

        private void OnCollisionEnter(Collision collision)
        {
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

