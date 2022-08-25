using UnityEngine;
using UnityEngine.Events;

namespace CartoonZombieVR.Gameplay
{
    public class Health : MonoBehaviour
    {
        public bool isDead = false;

        public UnityAction OnTakeDamage;
        public UnityAction OnDeath;

        private float startingHealth = 100f;
        private float currentHealth = 100f;
       
        public void SetInitialHealth(float health)
        {
            startingHealth = health;
            currentHealth = health;
        }

        public void TakeDamage(float amount)
        {
            if (isDead)
            {
                return;
            }

            currentHealth -= amount;
            OnTakeDamage?.Invoke();

            if (currentHealth <= 0f && !isDead)
            {
                Die();
            }
        }

        public void Heal(float amount)
        {
            currentHealth = Mathf.Max(currentHealth + amount, startingHealth);
        }

        private void Die()
        {
            isDead = true;
            OnDeath?.Invoke();
        }
    }
}

