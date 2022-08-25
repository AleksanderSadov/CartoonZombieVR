using UnityEngine;
using UnityEngine.AI;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private Animator animator;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
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
    }
}
