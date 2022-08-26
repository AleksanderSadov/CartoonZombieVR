using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyTypeConfig", menuName = "ScriptableObjects/EnemyTypeConfig", order = 220)]
    public class EnemyTypeConfig : ScriptableObject
    {
        public EnemyGeneralConfig generalConfig;

        [Header("Movement")]
        public bool overrideEnemyNavMeshValues = false;
        [ShowIf("overrideEnemyNavMeshValues")]
        public float movementSpeed = 2;
        [ShowIf("overrideEnemyNavMeshValues")]
        public float movementAngularSpeed = 120;
        [ShowIf("overrideEnemyNavMeshValues")]
        public float movementAcceleration = 1;
        [ShowIf("overrideEnemyNavMeshValues")]
        public float movementStoppingDistance = 4;
        [ShowIf("overrideEnemyNavMeshValues")]
        public bool movementAutoBraking = true;

        [Header("Attack")]
        public float attackRange = 20.0f;
        public float attackAngle = 20.0f;
        public float attackSpeed = 1.0f;

        [Header("Health")]
        public float health = 100.0f;

        [Header("Events")]
        public UnityAction OnConfigValuesChanged;

        public void OnValidate()
        {
            OnConfigValuesChanged?.Invoke();
        }
    }
}

