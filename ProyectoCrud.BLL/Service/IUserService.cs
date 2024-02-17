using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IUserService
    {
        Task<bool> Insert(User model);
        Task<bool> Update(User model);
        Task<bool> Delete(int id);
        Task<User> Get(int id);
        Task<IQueryable<User>> GetAll();
        Task<User> GetForName(string name);
    }
}
