using UnityEngine;
using UnityEngine.AI;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(FindTargetSensor))]
    [RequireComponent(typeof(SightSensor))]
    public class EnemyController : MonoBehaviour
    {
        public GameObject currentTarget;

        public bool isTargetInAttackRange => sightSensor.isTargetInAttackRange;
        public bool isTargetInAttackAngle => sightSensor.isTargetInAttackAngle;

        private EnemyMovement movement;
        private FindTargetSensor findTargetSensor;
        private SightSensor sightSensor;

        private void Awake()
        {
            movement = GetComponent<EnemyMovement>();
            findTargetSensor = GetComponent<FindTargetSensor>();
            sightSensor = GetComponent<SightSensor>();
        }

        public void FindTarget() => currentTarget = findTargetSensor.FindRandomTarget();
        public void FollowTarget(GameObject target) => movement.SetNavDestination(target.transform.position);
        public void ResetDestination() => movement.ResetDestination();
        public void OrientTowards(Vector3 lookPosition) => movement.OrientTowards(lookPosition);

        public void TryAttack()
        {

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
    }
}

