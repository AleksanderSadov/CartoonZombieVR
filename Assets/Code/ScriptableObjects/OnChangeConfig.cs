using UnityEngine;
using UnityEngine.Events;

namespace CartoonZombieVR.ScriptableObjects
{
    public class OnChangeConfig : ScriptableObject
    {
        [Header("Events")]
        public UnityAction OnConfigValuesChanged;

        public void OnValidate()
        {
            OnConfigValuesChanged?.Invoke();
        }
    }
}

