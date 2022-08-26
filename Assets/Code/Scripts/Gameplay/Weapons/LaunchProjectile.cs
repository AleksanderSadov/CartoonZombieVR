using CartoonZombieVR.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class LaunchProjectile : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Weapon Config")]
        private WeaponLauncherConfig weaponConfig = null;

        [SerializeField]
        [Tooltip("Fire Animator")]
        private Animator fireAnimator = null;

        [SerializeField]
        [Tooltip("The point that the project is created")]
        private Transform startPoint = null;

        private bool isReloading = false;

        public void Fire()
        {
            if (isReloading)
            {
                return;
            }

            GameObject newObject = Instantiate(weaponConfig.projectilePrefab, startPoint.position, startPoint.rotation, null);

            if (newObject.TryGetComponent(out Rigidbody rigidBody))
            {
                ApplyForce(rigidBody);
            }

            if (fireAnimator != null)
            {
                fireAnimator.SetTrigger("Fire");
            }

            if (weaponConfig.reloadDuration > 0)
            {
                isReloading = true;
                StartCoroutine(WaitForReload(weaponConfig.reloadDuration));
            }
        }

        void ApplyForce(Rigidbody rigidBody)
        {
            Vector3 force = startPoint.forward * weaponConfig.launchSpeed;
            rigidBody.AddForce(force);
        }

        IEnumerator WaitForReload(float reloadDuration)
        {
            yield return new WaitForSeconds(reloadDuration);
            isReloading = false;
        }
    }
}
