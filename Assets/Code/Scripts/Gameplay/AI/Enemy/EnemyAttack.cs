using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAttack : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void StartAttack()
        {
            animator.SetBool("Attack", true);
        }

        public void StopAttack()
        {
            animator.SetBool("Attack", false);
        }
    }
}

