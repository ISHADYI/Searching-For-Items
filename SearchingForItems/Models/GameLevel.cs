namespace SearchingForItems.Models
{
    public class GameLevel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BackgroundImageUrl { get; set; }
        public List<Word> Words { get; set; } = new List<Word>();

        public bool IsCompleted => Words.All(w => w.IsFound);
    }
}
