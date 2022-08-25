using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 2)]
    public class EnemyConfig : ScriptableObject
    {
        public float attackRange = 20.0f;
        public float attackAngle = 20.0f;
    }
}

