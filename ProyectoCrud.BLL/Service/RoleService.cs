using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<Role> _roleService;

        public RoleService(IGenericRepository<Role> roleService)
        {
            _roleService = roleService;
        }

        public async Task<bool> Delete(int id)
        {
            return await _roleService.Delete(id);
        }

        public async Task<Role> Get(int id)
        {
            return await _roleService.Get(id);  
        }

        public async Task<IQueryable<Role>> GetAll()
        {
            return await _roleService.GetAll();
        }

        public async Task<Role> GetForRole(string name)
        {
            IQueryable<Role> queryRolSQL = await _roleService.GetAll();
            Role role = queryRolSQL.FirstOrDefault(x => x.RoleName.Equals(name));
            if (role == null) throw new ArgumentNullException("Role not found");
            return role;
        }

        public async Task<bool> Insert(Role model)
        {
            return await _roleService.Insert(model);
        }

        public async Task<bool> Update(Role model)
        {
            return await _roleService.Update(model);
        }
    }
}
