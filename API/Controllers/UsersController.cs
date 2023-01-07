using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[Controller]")]
  public class UsersController : Controller
  {
    public readonly DataContext _context;
    public UsersController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
      var users = await _context.Users.ToListAsync();
      return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {

      return await _context.Users.FindAsync(id);
    }
  }
}