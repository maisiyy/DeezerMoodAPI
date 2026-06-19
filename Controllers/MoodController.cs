using Microsoft.AspNetCore.Mvc;
using SpotifyMoodAPI.Services;

namespace SpotifyMoodAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoodController : ControllerBase
    {
        private readonly DeezerService _deezer;

        public MoodController(DeezerService deezer)
        {
            _deezer = deezer;
        }

        [HttpGet]
        public async Task<IActionResult> GetByMood(
            [FromQuery] string mood = "happy",
            [FromQuery] int limit = 10)
        {
            if (string.IsNullOrWhiteSpace(mood))
                return BadRequest("Mood parameter is required.");

            var tracks = await _deezer.GetTracksByMoodAsync(mood, limit);

            return Ok(new {
                mood,
                count = tracks.Count,
                tracks
            });
        }
    }
}