namespace RadioEntryTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contest contest = new Contest()
                .EnterNumOfCandidates()
                .FillListOfCandidates()
                .SortListOfCandidates()
                .CreateTeamsAndPrint();
        }
    }
}
