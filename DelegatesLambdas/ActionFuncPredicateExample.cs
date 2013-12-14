using System;
using System.Collections.Generic;
using System.Web;
using DelegatesToLambdas.TestData;

namespace DelegatesToLambdas.DelegatesLambdas
{
    public class ActionFuncPredicateExample
    {
        private readonly List<TeamDTO> allTeams = new List<TeamDTO>
                                          {
                                              new TeamDTO("Flyers", "East"),
                                              new TeamDTO("Blackhawks", "West"),
                                              new TeamDTO("Blue Jackets", "West"),
                                              new TeamDTO("Capitals", "East")
                                          };

        public void PrintTeamNames()
        {
            Func<TeamDTO, string> printTeamName = x => x.TeamName;

            foreach (TeamDTO team in allTeams)
            {
                printTeamName(team);
            }
        }

        public void DisplayTeamsStartingWithBUsingFuncAndAction()
        {
            Func<IList<TeamDTO>, IList<TeamDTO>> getListOfTeamsStartingWithB = delegate(IList<TeamDTO> teams)
                                                               {
                                                                   IList<TeamDTO> teamsThatStartWithLetterB = new List<TeamDTO>();
                                                                   foreach (TeamDTO team in teams)
                                                                   {
                                                                       if (team.TeamName.StartsWith("B"))
                                                                       {
                                                                           teamsThatStartWithLetterB.Add(team);
                                                                       }
                                                                   }

                                                                   return teamsThatStartWithLetterB;
                                                               };

            Action<IList<TeamDTO>> printTeams = delegate(IList<TeamDTO> teams)
            {
                foreach (TeamDTO team in teams)
                {
                    HttpContext.Current.Response.Write(team.TeamName + "<br />");
                }
            };

            printTeams(getListOfTeamsStartingWithB(allTeams));
        }

        public void DisplayTeamsStartingWithBUsingPredicateAndAction()
        {
            Predicate<TeamDTO> filter = delegate(TeamDTO team) { return team.TeamName.StartsWith("B"); };
            IList<TeamDTO> teamsThatStartWithB = SelectTeamsByFilter(allTeams, filter);

            Action<IList<TeamDTO>> printTeams = delegate(IList<TeamDTO> teams)
                                                    {
                                                        foreach (TeamDTO team in teams)
                                                        {
                                                            HttpContext.Current.Response.Write(team.TeamName + "<br />");
                                                        }
                                                    };

            printTeams(teamsThatStartWithB);
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