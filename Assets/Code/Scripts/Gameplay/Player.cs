using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class Player : MonoBehaviour
    {
        public PlayerConfig playerConfig;

        private Health health;

        private void Start()
        {
            health = GetComponent<Health>();

            health.SetInitialHealth(playerConfig.health);
            health.OnTakeDamage += OnTakeDamage;
            health.OnDeath += OnDeath;
        }

        private void OnTakeDamage()
        {

        }

        private void OnDeath()
        {

        }
    }
}

