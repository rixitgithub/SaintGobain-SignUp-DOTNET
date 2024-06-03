using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignupApi.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly UserDetailContext _context;

        public UserDetailController(UserDetailContext context)
        {
            _context = context;
        }

        // GET: api/UserDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserDetails()
        {
            return await _context.UserDetails.ToListAsync();
        }

        // GET: api/UserDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetails>> GetUserDetails(int id)
        {
            var userDetails = await _context.UserDetails.FindAsync(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return userDetails;
        }

        // PUT: api/UserDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetails(int id, UserDetails userDetails)
        {
            if (id != userDetails.UserId)
            {
                return BadRequest();
            }

            // Decode base64 string to byte array if ProfilePhoto is provided
            if (!string.IsNullOrEmpty(userDetails.ProfilePhotoBase64))
            {
                userDetails.ProfilePhoto = Convert.FromBase64String(userDetails.ProfilePhotoBase64);
            }

            _context.Entry(userDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.UserDetails.ToListAsync());
        }

        // POST: api/UserDetail
        [HttpPost]
        public async Task<ActionResult<UserDetails>> PostUserDetails(UserDetails userDetails)
        {
            // Decode base64 string to byte array if ProfilePhoto is provided
            if (!string.IsNullOrEmpty(userDetails.ProfilePhotoBase64))
            {
                userDetails.ProfilePhoto = Convert.FromBase64String(userDetails.ProfilePhotoBase64);
            }

            _context.UserDetails.Add(userDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserDetails.ToListAsync());
        }

        // DELETE: api/UserDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDetails(int id)
        {
            var userDetails = await _context.UserDetails.FindAsync(id);
            if (userDetails == null)
            {
                return NotFound();
            }

            _context.UserDetails.Remove(userDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserDetails.ToListAsync());
        }

        private bool UserDetailsExists(int id)
        {
            return _context.UserDetails.Any(e => e.UserId == id);
        }
    }
}
