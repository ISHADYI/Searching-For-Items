using Microsoft.AspNetCore.Mvc;
using SearchingForItems.Data;
using SearchingForItems.Models;
using SearchingForItems.Services;

namespace SearchingForItems.Controllers
{
    public class GameController : Controller
    {
        private LocationRepository _locationRepository;
        private UserRepository _userRepository;
        private readonly ApiService? api;

        public GameController(LocationRepository locationRepository, UserRepository userRepository, ApiService? api)
        {
            _locationRepository = locationRepository;
            _userRepository = userRepository;
            this.api = api;
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
        public async Task<IActionResult> AddPointsUser()
        {
            var userId = HttpContext.Session.GetString("UserId");
            User currentUser = _userRepository.GetCurrentUser();
            int userScore = currentUser.Score;
            var result = await api.AddPointsAsync(userId, 11, userScore); // 11 - id игры

            if (result == true)
                return Ok();

            return BadRequest();
        }
    }
}