using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class TeamMember : MonoBehaviour
    {
        public TeamAffiliation teamAffiliation;

        private TeamManager teamManager;
        private Health health;

        private void Start()
        {
            teamManager = FindObjectOfType<TeamManager>();
            teamManager.AddMemberToTeam(this);

            health = GetComponent<Health>();
            if (health)
            {
                health.OnDeath += OnDeath;
            }
        }

        private void OnDeath()
        {
            RemoveMemberFromTeam();
        }

        private void OnDestroy()
        {
            RemoveMemberFromTeam();
        }

        private void RemoveMemberFromTeam()
        {
            if (teamManager)
            {
                teamManager.RemoveMemberFromTeam(this);
            }
        }
    }
}
