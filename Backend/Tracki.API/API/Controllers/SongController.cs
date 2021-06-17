using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllAllowed")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class SongController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public SongController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Song>>> SearchForSongs(string searchText)
        {
            var songs = _context.Songs.Where(s => s.Name.Contains(searchText)).ToList();
            
            if(songs[0].Artist == null)
                Console.WriteLine("NULL KURVA PROČ!!");

            if (songs.Count != 0)
            {
                return songs;
            }

            return BadRequest("Song does not exist.");
        }
    }
}