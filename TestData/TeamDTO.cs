namespace DelegatesToLambdas.TestData
{
    public class TeamDTO
    {
        public TeamDTO(string teamName, string conference)
        {
            TeamName = teamName;
            Conference = conference;
        }

        public string TeamName { get; private set; }
        public string Conference { get; private set; }
    }
}