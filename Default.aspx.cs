using System;
using System.Web.UI;
using DelegatesToLambdas.DelegatesLambdas;
using DelegatesToLambdas.TestData;

namespace DelegatesToLambdas
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Explain delegates as function pointers and show that. (benefits + problems)
            // explain how they're sorta like interfaces for functions - you show what type you're looking for and then pass in a function that conforms
            // also - explain that you can put public,private, etc. on them to scope them across classes, etc.
            //DelegateExample();

            // 2. Explain inline delegates (benefits + problems)
            //InlineDelegateExample();

            // 3. Explain Action<T>, Func<T,TResult> and Predicate<T> as helpers (benefits over delegates)
            //ActionFuncPredicateExample();

            // 4. Explain lambdas and how they're just readable delegates
            Lambdas();
        }

        private void Lambdas()
        {
            Response.Write("LambdaExample" + "<br />");
            var example = new LambdaExample();
           
            foreach (TeamDTO team in example.GetTeamsThatStarWithB())
            {
                Response.Write(team.TeamName + "<br />");
            }
        }

        private void ActionFuncPredicateExample()
        {
            Response.Write("ActionFuncPredicateExample" + "<br />");
            var example = new ActionFuncPredicateExample();
            //example.DisplayTeamsStartingWithBUsingPredicateAndAction();
            example.DisplayTeamsStartingWithBUsingFuncAndAction();
        }

        private void InlineDelegateExample()
        {
            Response.Write("InlineDelegateExample" + "<br />");
            var example = new InlineDelegateExample();

            foreach(TeamDTO team in example.GetTeamsInEasternConference())
            {
                Response.Write(team.TeamName + "<br />");
            }
        }

        private void DelegateExample()
        {
            Response.Write("DelegateExample" + "<br />");
            var example = new DelegateExample();
            foreach (TeamDTO team in example.GetTeamsInEasternConference())
            {
                Response.Write(team.TeamName + "<br />");
            }
        }
    }
}