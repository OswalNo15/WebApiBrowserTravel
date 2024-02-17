using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepo;
        public UserService(IGenericRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _userRepo.Delete(id);
        }

        public async Task<User> Get(int id)
        {
            return await _userRepo.Get(id);
        }

        public async Task<IQueryable<User>> GetAll()
        {
            return await _userRepo.GetAll();
        }

        public async Task<User> GetForName(string name)
        {
            IQueryable<User> queryUserSQL = await _userRepo.GetAll();
            User user = queryUserSQL.Where(c => c.Name == name).FirstOrDefault();
            if (user == null) throw new ArgumentNullException("User not found");

            return user;
        }

        public async Task<bool> Insert(User model)
        {
            return await _userRepo.Insert(model);
        }

        public async Task<bool> Update(User model)
        {
            return await _userRepo.Update(model);
        }
    }
}
