using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class SightSensor : MonoBehaviour
    {
        public EnemyTypeConfig enemyConfig;

        public bool isTargetInAttackRange;
        public bool isTargetInAttackAngle;

        private EnemyController enemyController;

        private void Start()
        {
            enemyController = GetComponent<EnemyController>();
        }

        private void FixedUpdate()
        {
            CheckTargetInSight();
        }

        protected virtual void CheckTargetInSight()
        {
            if (enemyController.currentTarget == null)
            {
                return;
            }

            Vector3 direction = (enemyController.currentTarget.transform.position - transform.position).normalized;
            float targetAngle = Vector3.Angle(direction, transform.forward);

            isTargetInAttackRange = Vector3.Distance(transform.position, enemyController.currentTarget.transform.position) <= enemyConfig.attackRange;
            isTargetInAttackAngle = targetAngle < enemyConfig.attackAngle;
        }
    }
}

