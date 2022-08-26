using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyAttack))]
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(FindTargetSensor))]
    [RequireComponent(typeof(SightSensor))]
    public class EnemyController : MonoBehaviour
    {
        public GameObject currentTarget;

        public bool isTargetInAttackRange => sightSensor.isTargetInAttackRange;
        public bool isTargetInAttackAngle => sightSensor.isTargetInAttackAngle;

        public UnityAction OnDeath;

        private Enemy enemy;
        private Animator animator;
        private EnemyMovement movement;
        private EnemyAttack attack;
        private Health health;
        private FindTargetSensor findTargetSensor;
        private SightSensor sightSensor;

        private void Awake()
        {
            enemy = GetComponent<Enemy>();
            animator = GetComponent<Animator>();
            movement = GetComponent<EnemyMovement>();
            attack = GetComponent<EnemyAttack>();
            health = GetComponent<Health>();
            findTargetSensor = GetComponent<FindTargetSensor>();
            sightSensor = GetComponent<SightSensor>();

            health.SetInitialHealth(enemy.typeConfig.health);
            health.OnTakeDamage += OnTakeDamage;
            health.OnDeath += OnHealthDeath;
        }

        private void OnDestroy()
        {
            health.OnTakeDamage -= OnTakeDamage;
            health.OnDeath -= OnHealthDeath;
        }

        public void FindTarget() => currentTarget = findTargetSensor.FindRandomTarget();
        public void FollowTarget(GameObject target) => movement.SetNavDestination(target.transform.position);
        public void ResetDestination() => movement.ResetDestination();
        public void DisableNavAgent() => movement.DisableNavAgent();
        public void OrientTowards(Vector3 lookPosition) => movement.OrientTowards(lookPosition);
        public void StartAttack() => attack.StartAttack();
        public void StopAttack() => attack.StopAttack();

        public void TryAttack()
        {
            if (
                currentTarget == null
                || !isTargetInAttackRange
                || !isTargetInAttackAngle
            )
            {
                StopAttack();
                return;
            }

            StartAttack();
        }

        public void TryNewAttackPosition()
        {
            if (!movement.HasReachedDestination())
            {
                return;
            }

            float attackRange = sightSensor.enemyConfig.attackRange;
            Vector3 randomDirection = new Vector3(Random.Range(attackRange / 2, attackRange), transform.position.y, Random.Range(attackRange / 2, attackRange));
            float randomSign = Random.Range(0f, 1f) >= 0.5f ? 1f : -1f;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(currentTarget.transform.position + randomDirection * randomSign, out hit, sightSensor.enemyConfig.attackRange, 1 << NavMesh.GetAreaFromName("Walkable")))
            {
                movement.SetNavDestination(hit.position);
            }
        }

        public void DisableCollider()
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }

        private void OnTakeDamage()
        {
            animator.SetTrigger("TakeDamage");

            SkinnedMeshRenderer renderer = GetComponentInChildren<SkinnedMeshRenderer>();
            StartCoroutine(ChangeEnemyColor(renderer, renderer.material.color, enemy.typeConfig.generalConfig.flashOnGetHitDuration));
            renderer.material.color = enemy.typeConfig.generalConfig.flashOnGetHitColor;
        }

        private void OnHealthDeath()
        {
            animator.SetTrigger("Die");
            StopAttack();
            ResetDestination();
            DisableNavAgent();
            DisableCollider();
            Destroy(gameObject, enemy.typeConfig.generalConfig.destroyAfterDeathSeconds);
            OnDeath?.Invoke();
        }

        private IEnumerator ChangeEnemyColor(SkinnedMeshRenderer renderer, Color newColor, float delay)
        {
            yield return new WaitForSeconds(delay);
            renderer.material.color = newColor;

        }
    }
}

