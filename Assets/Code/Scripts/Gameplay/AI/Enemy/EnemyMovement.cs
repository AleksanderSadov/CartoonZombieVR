using CartoonZombieVR.General;
using UnityEngine;
using UnityEngine.AI;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class EnemyMovement : MonoBehaviour
    {
        public bool isMoving => navMeshAgent.velocity.magnitude > 0;

        private Enemy enemy;
        private NavMeshAgent navMeshAgent;
        private Animator animator;

        private void Awake()
        {
            enemy = GetComponent<Enemy>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            enemy.OnEnemyTypeChanged += UpdateNavMeshFromConfig;
            UpdateNavMeshFromConfig();
        }

        private void Update()
        {
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        }

        private void OnDisable()
        {
            enemy.OnEnemyTypeChanged -= UpdateNavMeshFromConfig;
        }

        public void SetNavDestination(Vector3 destination)
        {
            if (navMeshAgent && navMeshAgent.isOnNavMesh)
            {
                navMeshAgent.SetDestination(destination);
            }
        }

        public void ResetDestination()
        {
            if (navMeshAgent && navMeshAgent.isOnNavMesh)
            {
                navMeshAgent.ResetPath();
            }
        }

        public void DisableNavAgent()
        {
            navMeshAgent.enabled = false;
        }

        public void OrientTowards(Vector3 lookPosition)
        {
            Vector3 lookDirection = Vector3.ProjectOnPlane(lookPosition - transform.position, Vector3.up).normalized;
            if (lookDirection.sqrMagnitude != 0f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * navMeshAgent.angularSpeed);
            }
        }

        public bool HasReachedDestination()
        {
            if
                (navMeshAgent.enabled
                && !navMeshAgent.pathPending
                && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance
                && (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
            )
            {
                return true;
            }

            return false;
        }

        private void UpdateNavMeshFromConfig()
        {
            if (enemy.typeConfig.overrideEnemyNavMeshValues)
            {
                navMeshAgent.speed = enemy.typeConfig.movementSpeed;
                navMeshAgent.angularSpeed = enemy.typeConfig.movementAngularSpeed;
                navMeshAgent.acceleration = enemy.typeConfig.movementAcceleration;
                navMeshAgent.stoppingDistance = enemy.typeConfig.movementStoppingDistance;
                navMeshAgent.autoBraking = enemy.typeConfig.movementAutoBraking;
            }
        }
    }
}
