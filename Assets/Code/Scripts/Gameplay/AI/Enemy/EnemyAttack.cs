using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Animator))]
    public class EnemyAttack : MonoBehaviour
    {
        private Enemy enemy;
        private Animator animator;

        private void Awake()
        {
            enemy = GetComponent<Enemy>();
            animator = GetComponent<Animator>();
            UpdateAttackSpeedFromConfig();
            enemy.config.OnConfigValuesChanged += UpdateAttackSpeedFromConfig;
        }

        public void StartAttack()
        {
            animator.SetBool("Attack", true);
        }

        public void StopAttack()
        {
            animator.SetBool("Attack", false);
        }

        private void UpdateAttackSpeedFromConfig()
        {
            animator.SetFloat("AttackSpeed", enemy.config.attackSpeed);
        }
    }
}

