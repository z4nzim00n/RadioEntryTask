namespace RadioEntryTask
{
    public class Contest
    {
        public byte k { get; private set; }
        private List<Candidate> candidates = new List<Candidate>();
        public int[] team1, team2;

    
        public Contest EnterNumOfCandidates()
        {
            k = byte.Parse(Console.ReadLine());
            return this;
        }

        public Contest FillListOfCandidates()
        {
            for (int i = 0; i < k; i++)
            {
                string[] input = Console.ReadLine().Split();
                int groupNum = int.Parse(input[0]);
                int[] roundScore = input.Skip(1).Select(int.Parse).ToArray();
                candidates.Add(new Candidate(i + 1, groupNum, roundScore));
            }

            SetPersonStatus();
            return this;
        }

        public Contest SortListOfCandidates()
        {
            candidates = candidates.OrderByDescending(c => c.globalScore).ToList();
            return this;
        }

        private void SetPersonStatus()
        {
            int maxGroupNum = 11;

            foreach (Candidate candidate in candidates)
            {
                if (candidate.groupNumber == maxGroupNum)
                {
                    candidate.typePerson = TypePerson.lead;
                }
                else
                {
                    candidate.typePerson = TypePerson.common;
                }
            }
        }

        public Contest CreateTeamsAndPrint()
        {
            team1 = candidates.Take(4).Select(c => c.candidateNumber).ToArray();
            team2 = candidates.Skip(4).Where(c => c.typePerson != TypePerson.lead)
                .Take(4).Select(c => c.candidateNumber).ToArray();
            
            PrintResult(team1, team2);
            return this;
        }

        private void PrintResult(params int[][] teams)
        {
            foreach (var team in teams)
            {
                Console.WriteLine(string.Join(" ", team));
            }
        }

    }
}
