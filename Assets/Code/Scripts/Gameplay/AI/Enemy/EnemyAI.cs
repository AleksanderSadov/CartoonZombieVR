using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(EnemyController))]
    public class EnemyAI : MonoBehaviour
    {
        public enum AIState
        {
            FindTarget,
            Follow,
            Attack,
            Dead,
        }

        public AIState aiState;

        private EnemyController enemyController;

        private void Start()
        {
            enemyController = GetComponent<EnemyController>();
            aiState = AIState.FindTarget;
            enemyController.OnDeath += OnDeath;
        }

        private void Update()
        {
            UpdateAiStateTransitions();
            UpdateCurrentAiState();
        }

        private void OnDestroy()
        {
            enemyController.OnDeath -= OnDeath;
        }

        private void UpdateAiStateTransitions()
        {
            switch (aiState)
            {
                case AIState.FindTarget:
                    if (enemyController.currentTarget != null)
                    {
                        aiState = AIState.Follow;
                    }
                    break;
                case AIState.Follow:
                    if (enemyController.isTargetInAttackRange)
                    {
                        aiState = AIState.Attack;
                        enemyController.ResetDestination();
                    }
                    break;
                case AIState.Attack:
                    if (
                        enemyController.currentTarget == null
                        || !enemyController.currentTarget.gameObject.activeSelf
                        || !enemyController.isTargetInAttackRange
                    )
                    {
                        aiState = AIState.FindTarget;
                        enemyController.StopAttack();
                    }
                    break;
            }
        }

        private void UpdateCurrentAiState()
        {
            switch (aiState)
            {
                case AIState.FindTarget:
                    enemyController.FindTarget();
                    break;
                case AIState.Follow:
                    enemyController.FollowTarget(enemyController.currentTarget);
                    break;
                case AIState.Attack:
                    enemyController.OrientTowards(enemyController.currentTarget.transform.position);
                    enemyController.TryAttack();
                    enemyController.TryNewAttackPosition();
                    break;
            }
        }

        private void OnDeath()
        {
            aiState = AIState.Dead;
        }
    }
}

