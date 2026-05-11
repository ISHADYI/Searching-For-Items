using Microsoft.AspNetCore.Mvc;
using SearchingForItems.Models;

public class GameController : Controller
{
    public IActionResult Levels()
    {
        var levels = new List<GameLevel>
        {
            new GameLevel
            {
                Id = 1,
                Title = "Кухня",
                BackgroundImageUrl = "/images/kitchen.jpg"
            },

            new GameLevel
            {
                Id = 2,
                Title = "Двор",
                BackgroundImageUrl = "/images/kitchen.jpg"
            },

            new GameLevel
            {
                Id = 3,
                Title = "Гостиная",
                BackgroundImageUrl= "/images/kitchen.jpg"
            }
        };

        return View(levels);
    }
    public IActionResult Index()
    {
        var level = new GameLevel
        {
            Title = "Тайная комната (Уровень 1)",
            BackgroundImageUrl = "/images/kitchen.jpg",
            Words = new List<Word> {
                new Word { Id = 1, Ossetian = "Къухмæрзæн", Top = 60, Left = 30, ImageUrl = "/images/towel.png" },
                new Word { Id = 2, Ossetian = "Чырыг", Top = 65, Left = 60, ImageUrl = "/images/box.png" }
            }
        };

        return View("Game", level);
    }
}