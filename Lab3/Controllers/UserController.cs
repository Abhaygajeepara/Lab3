using Lab3.DatabaseContext;
using Lab3.Model;
using Lab3.Model.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Lab3.Controllers
{
   
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;
        private UserRepository userRepository;

        public UserController(MyDatabaseContext dbContext) {
        _dbContext = dbContext;
            userRepository = new UserRepository(dbContext);
        }

        [HttpGet]
        [Route("getUser")]
        public async Task<ActionResult> getUserList() {
            var result = userRepository.getUsers();

            return Ok(result.Result);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult> addUser(UserInputModel userInputModel)
        {
            var userModel = userRepository.addUser(userInputModel);
            
            return Ok(userModel.Result);
        }


        [HttpGet]
        [Route("getUserByID")]
        public async Task<ActionResult> getUserByID(int id)
        {
           
            var result = await userRepository.getUserByID(id);
            
            if (result!= null)
            return Ok(result);

            return NotFound();


        }

        [HttpPost]
        [Route("updateUser")]
        public async Task<ActionResult> updateUser(int id, UserInputModel userInputModel)
        {

            var result = await userRepository.updateUser(id,userInputModel);

            if (result != null)
                return Ok(result);

            return NotFound();


        }


    }
}
