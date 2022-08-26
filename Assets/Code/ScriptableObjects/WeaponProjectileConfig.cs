using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponProjectileConfig", menuName = "ScriptableObjects/WeaponProjectileConfig", order = 310)]
    public class WeaponProjectileConfig : ScriptableObject
    {
        public string targetTag;
        public float damage = 25.0f;
        public float minimumProjectileVelocityToInflictDamage = 0.1f;
    }
}

