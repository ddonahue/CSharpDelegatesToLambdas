using System.Collections.Generic;
using DelegatesToLambdas.TestData;

namespace DelegatesToLambdas.DelegatesLambdas
{
    public class DelegateExample
    {
        delegate bool Filter(TeamDTO team);

        public IList<TeamDTO> GetTeamsInEasternConference()
        {
            IList<TeamDTO> allTeams = new List<TeamDTO>
                                          {
                                              new TeamDTO("Flyers", "East"),
                                              new TeamDTO("Blackhawks", "West"),
                                              new TeamDTO("Blue Jackets", "West"),
                                              new TeamDTO("Capitals", "East")
                                          };

            IList<TeamDTO> easternTeams = SelectTeamsByFilter(allTeams, IsEasternConferenceTeam);
            return easternTeams;
        }

        private static IList<TeamDTO> SelectTeamsByFilter(IEnumerable<TeamDTO> teams, Filter filter)
        {
            var filteredTeams = new List<TeamDTO>();
            foreach(TeamDTO team in teams)
            {
                if(filter(team))
                {
                    filteredTeams.Add(team);
                }
            }

            return filteredTeams;
        }

        private static bool IsEasternConferenceTeam(TeamDTO team)
        {
            return team.Conference == "East";
        }
    }
}