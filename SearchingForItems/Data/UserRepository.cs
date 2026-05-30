// Data/UserRepository.cs
using SearchingForItems.Models;

namespace SearchingForItems.Data
{
    public class UserRepository
    {
        private User currentUser;

        public UserRepository()
        {
            currentUser = new User(1, 0);
        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        public void UpdateScore(int newScore)
        {
            currentUser.Score = newScore;
        }

        public void AddScore(int points)
        {
            currentUser.Score += points;
        }

        public void SubtractScore(int points)
        {
            currentUser.Score -= points;
        }

        public void ResetScore()
        {
            currentUser.Score = 0;
        }
    }
}