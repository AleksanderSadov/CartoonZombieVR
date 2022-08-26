using UnityEngine;
using UnityEngine.Events;

namespace CartoonZombieVR.Gameplay
{
    public class EnemyMeleeWeapon : MonoBehaviour
    {
        public UnityEvent<Collider> weaponHit; 

        private void OnTriggerEnter(Collider collider)
        {
            weaponHit?.Invoke(collider);
        }
    }
}
