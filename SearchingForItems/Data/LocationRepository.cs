using SearchingForItems.Models;
using System.Text.Json;

namespace SearchingForItems.Data
{
    public class LocationRepository
    {
        private List<GameLevel> levels;

        public LocationRepository()
        {
            string jsonString = File.ReadAllText("Data/Locations.json");
            levels = JsonSerializer.Deserialize<List<GameLevel>>(jsonString);
        }

        public List<GameLevel> GetAll()
        {
            return levels;
        }
    }
}
