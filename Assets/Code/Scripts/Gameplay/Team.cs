using System.Collections.Generic;

namespace CartoonZombieVR.Gameplay
{
    public enum TeamAffiliation
    {
        Players,
        Enemies,
    }

    [System.Serializable]
    public class Team
    {
        public TeamAffiliation teamAffiliation;
        public List<TeamMember> members = new List<TeamMember>();
    }
}
