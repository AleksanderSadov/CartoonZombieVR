using System.Collections.Generic;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class TeamManager : MonoBehaviour
    {
        public List<Team> teams;

        public void AddMemberToTeam(TeamMember teamMember)
        {
            Team team = GetTeam(teamMember.teamAffiliation);

            if (team == null)
            {
                return;
            }

            if (!team.members.Contains(teamMember))
            {
                team.members.Add(teamMember);
            }
        }

        public void RemoveMemberFromTeam(TeamMember teamMember)
        {
            Team team = GetTeam(teamMember.teamAffiliation);

            if (team == null)
            {
                return;
            }

            if (team.members.Contains(teamMember))
            {
                team.members.Remove(teamMember);
            }
        }

        public Team GetTeam(TeamAffiliation teamAffiliation)
        {
            foreach (Team team in teams)
            {
                if (team.teamAffiliation == teamAffiliation)
                {
                    return team;
                }
            }

            return null;
        }

        public Team GetRivalTeam(TeamAffiliation allyTeamAffiliation)
        {
            foreach (Team team in teams)
            {
                if (team.teamAffiliation != allyTeamAffiliation)
                {
                    return team;
                }
            }

            return null;
        }
    }
}

