using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 112)]
    public class PlayerConfig : OnChangeConfig
    {
        [Header("XR Interactions")]
        public PlayerXRInteractionType playerXRInteractionType = PlayerXRInteractionType.FreeRoam;

        [Header("Health")]
        public float health = 100.0f;
        public bool isInvincible = false;
        public float stopHealAfterHitDelay = 5.0f;
        public float continuousHealSpeed = 5.0f;

        [Header("Get Hit Visual Effects")]
        public float getHitVignetteDuration = 0.5f;
        public float playerDeathExposureDarkValue = -5.0f;
        public float playerDeathDarkenScreenSpeed = 1.0f;
    }

    public enum PlayerXRInteractionType
    {
        FreeRoam,
        Teleport,
    }
}

