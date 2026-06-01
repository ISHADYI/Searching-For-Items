namespace SearchingForItems.Models
{
    public class User
    {
        public User(int id, int score)
        {
            Id = id;
            Score = score;
        }

        public int Id { get; set; }
        public int Score { get; set; } = 0;
    }
}
