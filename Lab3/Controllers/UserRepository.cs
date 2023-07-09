using Lab3.DatabaseContext;
using Lab3.Model;
using Lab3.Model.InputModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Controllers
{
    public class UserRepository
    {

       private readonly MyDatabaseContext _dbContext;
        public UserRepository(MyDatabaseContext dbContext) {
            _dbContext = dbContext;
        }
        public Task<List<UserModel>> getUsers() {

            return _dbContext.users.ToListAsync();
        }
        public async Task<UserModel> addUser(UserInputModel userInputModel)
        {
            UserModel userModel = new UserModel();
            userModel.Id = IdGenerator.GenerateId();
            userModel.name = userInputModel.name;
            userModel.email = userInputModel.email;
            userModel.password = userInputModel.password;
            _dbContext.users.Add(userModel);
            _dbContext.SaveChanges();
            return userModel;
        }

        public async Task<Object> getUserByID(int id)
        {
            var result = await _dbContext.users.FirstOrDefaultAsync(e => e.Id == id);
            
                return result;

        }
        public async Task<Object> updateUser(int id, UserInputModel userInputModel)
        {
            var result = await _dbContext.users.FirstOrDefaultAsync(e => e.Id == id);

            if (result != null) { 
                if(userInputModel.name.Length>0)
                    result.name = userInputModel.name;
                    result.email = userInputModel.email;
                    result.password = userInputModel.password;
              await _dbContext.SaveChangesAsync();
                return result;
            }


            return null;

        }
    }
}
