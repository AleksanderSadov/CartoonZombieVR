using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAttack : MonoBehaviour
    {
        public EnemyConfig enemyConfig;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            UpdateAttackSpeedFromConfig();
            enemyConfig.OnConfigValuesChanged += UpdateAttackSpeedFromConfig;
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
            animator.SetFloat("AttackSpeed", enemyConfig.attackSpeed);
        }
    }
}

