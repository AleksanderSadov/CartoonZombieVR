using UnityEngine;
using UnityEngine.Audio;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponLauncherConfig", menuName = "ScriptableObjects/WeaponLauncherConfig", order = 305)]
    public class WeaponLauncherConfig : ScriptableObject
    {
        [Header("General")]
        public GameObject projectilePrefab;
        public float launchSpeed = 1.0f;
        public float reloadDuration = 1.0f;

        [Header("Audio")]
        public AudioClip audioFireClip;
        public float audioFirePitchRange = 0;
        public AudioMixerGroup audioFireMixerGroup;
    }
}

