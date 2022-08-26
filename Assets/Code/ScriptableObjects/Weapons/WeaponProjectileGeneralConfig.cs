using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponProjectileGeneralConfig", menuName = "ScriptableObjects/WeaponProjectileGeneralConfig", order = 308)]
    public class WeaponProjectileGeneralConfig : ScriptableObject
    {
        [Tooltip("Projectile is destroyed after its launched and lifetime expired")]
        public float lifetime = 5.0f;
    }
}

