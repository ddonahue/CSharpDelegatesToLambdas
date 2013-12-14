using System;
using System.Collections.Generic;
using System.Web;
using DelegatesToLambdas.TestData;

namespace DelegatesToLambdas.DelegatesLambdas
{
public class LambdaExample
    {
        public IList<TeamDTO> GetTeamsThatStarWithB()
        {
            IList<TeamDTO> allTeams = new List<TeamDTO>
                                          {
                                              new TeamDTO("Flyers", "East"),
                                              new TeamDTO("Blackhawks", "West"),
                                              new TeamDTO("Blue Jackets", "West"),
                                              new TeamDTO("Capitals", "East")
                                          };

            return SelectTeamsByFilter(allTeams, team => team.TeamName.StartsWith("B"));
        }

        public void PrintTeamsThatStarWithB()
        {
            var allTeams = new List<TeamDTO>
                                          {
                                              new TeamDTO("Flyers", "East"),
                                              new TeamDTO("Blackhawks", "West"),
                                              new TeamDTO("Blue Jackets", "West"),
                                              new TeamDTO("Capitals", "East")
                                          };

            allTeams.ForEach(x =>
                                 {
                                     if (x.TeamName.StartsWith("B")) HttpContext.Current.Response.Write(x.TeamName + "<br />");
                                 }
                );
        }

        private static IList<TeamDTO> SelectTeamsByFilter(IEnumerable<TeamDTO> teams, Predicate<TeamDTO> filter)
        {
            var filteredTeams = new List<TeamDTO>();
            foreach (TeamDTO team in teams)
            {
                if (filter(team))
                {
                    filteredTeams.Add(team);
                }
            }

            return filteredTeams;
        }
    }
}