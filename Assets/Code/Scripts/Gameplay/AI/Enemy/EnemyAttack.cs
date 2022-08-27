using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Animator))]
    public class EnemyAttack : MonoBehaviour
    {
        private Enemy enemy;
        private Animator animator;
        private EnemyMeleeWeapon meleeWeapon;
        private bool canAttackDamage = false;
        private bool isPlayerHitOnCurrentAnimation = false;

        private void Awake()
        {
            enemy = GetComponent<Enemy>();
            animator = GetComponent<Animator>();

            meleeWeapon = GetComponentInChildren<EnemyMeleeWeapon>();
            meleeWeapon.weaponHit.AddListener(CheckHit);

            enemy.OnConfigValuesChanged += UpdateAttackSpeedFromConfig;
            UpdateAttackSpeedFromConfig();
        }

        private void OnDestroy()
        {
            enemy.OnConfigValuesChanged -= UpdateAttackSpeedFromConfig;
            meleeWeapon.weaponHit.RemoveListener(CheckHit);
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
            animator.SetFloat("AttackSpeed", enemy.typeConfig.attackSpeed);
        }

        private void CheckHit(Collider collider)
        {
            if (
                !collider.CompareTag(enemy.typeConfig.attackTargetTag)
                || !canAttackDamage
                || isPlayerHitOnCurrentAnimation
            )
            {
                return;
            }

            Health health = collider.gameObject.GetComponent<Health>();
            if (health == null)
            {
                return;
            }

            health.TakeDamage(enemy.typeConfig.attackDamage);
            isPlayerHitOnCurrentAnimation = true;
        }

        private void OnAttackBegin(AnimationEvent animationEvent)
        {
            canAttackDamage = false;
            isPlayerHitOnCurrentAnimation = false;
        }

        private void OnAttackCanDamage(AnimationEvent animationEvent)
        {
            canAttackDamage = true;
        }

        private void OnAttackEnd(AnimationEvent animationEvent)
        {
            canAttackDamage = false;
            isPlayerHitOnCurrentAnimation = false;
        }
    }
}

