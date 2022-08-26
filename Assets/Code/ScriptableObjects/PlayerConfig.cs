using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig", order = 112)]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Health")]
        public float health = 100.0f;
    }
}

