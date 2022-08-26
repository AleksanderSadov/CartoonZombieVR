using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponLauncherConfig", menuName = "ScriptableObjects/WeaponLauncherConfig", order = 305)]
    public class WeaponLauncherConfig : ScriptableObject
    {
        public GameObject projectilePrefab;
        public float launchSpeed = 1.0f;
        public float reloadDuration = 1.0f;
    }
}

