namespace RadioEntryTask
{
    public enum TypePerson { lead, common }
    public class Candidate(int id, int groupNum, int[] roundScore)
    {
        public int candidateNumber = id;
        public int groupNumber = groupNum;
        public int[] roundScore = roundScore;
        public int globalScore = roundScore.Sum();
        public TypePerson typePerson;
    }
}
