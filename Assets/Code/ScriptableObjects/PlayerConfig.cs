using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 112)]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Health")]
        public float health = 100.0f;
        public float getHitVignetteDuration = 0.5f;
        public float stopHealAfterHitDelay = 5.0f;
        public float continuousHealSpeed = 5.0f;
    }
}

