using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IRoleService
    {
        Task<bool> Insert(Role model);
        Task<bool> Update(Role model);
        Task<bool> Delete(int id);
        Task<Role> Get(int id);
        Task<IQueryable<Role>> GetAll();
        Task<Role> GetForRole(string name);
    }
}
