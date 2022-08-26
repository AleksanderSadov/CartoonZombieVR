using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EnemyGeneralConfig", menuName = "ScriptableObjects/EnemyGeneralConfig", order = 210)]
    public class EnemyGeneralConfig : ScriptableObject
    {
        [Header("Health")]
        public Color flashOnGetHitColor;
        public float flashOnGetHitDuration = 0.25f;
        public float destroyAfterDeathSeconds = 10.0f;
    }
}

