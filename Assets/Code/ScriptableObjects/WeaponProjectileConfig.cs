using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponProjectileConfig", menuName = "ScriptableObjects/WeaponProjectileConfig", order = 3)]
    public class WeaponProjectileConfig : ScriptableObject
    {
        public string targetTag;
        public float damage = 25.0f;
    }
}

