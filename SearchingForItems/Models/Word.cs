namespace SearchingForItems.Models
{
    public class Word
    {
        public int Id {  get; set; }
        public string Ossetian { get; set; }
        public string Russian { get; set; }
        //public string AudioUrl { get; set; } ???
        public string ImageUrl { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public bool IsFound { get; set; } = false;


    }
}
