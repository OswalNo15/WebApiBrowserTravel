using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class IdTypeService : IIdTypeService
    {
        private readonly IIdTypeService _IdTypeService;

        public IdTypeService(IIdTypeService IdTypeService)
        {
            _IdTypeService = IdTypeService;
        }

        public async Task<bool> Delete(int id)
        {
            return await _IdTypeService.Delete(id);
        }

        public async Task<IdType> Get(int id)
        {
            return await _IdTypeService.Get(id);
        }

        public async Task<IQueryable<IdType>> GetAll()
        {
            return await _IdTypeService.GetAll();
        }

        public async Task<IdType> GetForRole(int id)
        {
            IQueryable<IdType> queryRolSQL = await _IdTypeService.GetAll();
            IdType role = queryRolSQL.FirstOrDefault(x => x.IdIdtype.Equals(id));
            if (role == null) throw new ArgumentNullException("IdType not found");
            return role;
        }

        public async Task<bool> Insert(IdType model)
        {
            return await _IdTypeService.Insert(model);

        }

        public async Task<bool> Update(IdType model)
        {
            return await _IdTypeService.Update(model);
        }
    }
}
