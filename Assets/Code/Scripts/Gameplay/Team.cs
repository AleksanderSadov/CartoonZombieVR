using System.Collections.Generic;

namespace CartoonZombieVR.Gameplay
{
    public enum TeamAffiliation
    {
        PLAYERS,
        ENEMIES,
    }

    [System.Serializable]
    public class Team
    {
        public TeamAffiliation teamAffiliation;
        public List<TeamMember> members = new List<TeamMember>();
    }
}
