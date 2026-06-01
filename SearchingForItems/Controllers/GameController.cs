using Microsoft.AspNetCore.Mvc;
using SearchingForItems.Data;
using SearchingForItems.Models;

namespace SearchingForItems.Controllers
{
    public class GameController : Controller
    {
        private LocationRepository _locationRepository;
        private UserRepository _userRepository;

        public GameController(LocationRepository locationRepository, UserRepository userRepository)
        {
            _locationRepository = locationRepository;
            _userRepository = userRepository;
        }

        public IActionResult Levels()
        {
            List<GameLevel> levels = _locationRepository.GetAll();
            return View(levels);
        }

        public IActionResult Index(int id)
        {
            _userRepository.ResetScore();

            var level = _locationRepository.TryGetById(id);
            return View("Game", level);
        }

        [HttpPost]
        public IActionResult ProcessClick([FromBody] bool isRight)
        {
            User currentUser = _userRepository.GetCurrentUser();
            int currentScore = currentUser.Score;

            if (isRight)
            {
                _userRepository.AddScore(10);
                currentScore += 10;
            }
            else
            {
                _userRepository.SubtractScore(5);
                currentScore -= 5;
            }
            return Ok(new { newScore = currentScore });
        }

        [HttpGet]
        public IActionResult GetCurrentScore()
        {
            User currentUser = _userRepository.GetCurrentUser();
            return Ok(new { score = currentUser.Score });
        }
    }
}