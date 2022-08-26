using UnityEngine;
using UnityEngine.Events;

namespace CartoonZombieVR.Gameplay
{
    public class Health : MonoBehaviour
    {
        public float currentHealth { get; private set; } = 100f;
        public float startingHealth { get; private set; } = 100f;
        public bool isDead = false;

        public UnityAction OnTakeDamage;
        public UnityAction OnDeath;
       
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
            currentHealth = Mathf.Min(currentHealth + amount, startingHealth);
        }

        private void Die()
        {
            isDead = true;
            OnDeath?.Invoke();
        }
    }
}

