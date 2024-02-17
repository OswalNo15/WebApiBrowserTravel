using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IIdTypeService
    {
        Task<bool> Insert(IdType model);
        Task<bool> Update(IdType model);
        Task<bool> Delete(int id);
        Task<IdType> Get(int id);
        Task<IQueryable<IdType>> GetAll();
        Task<IdType> GetForRole(int id);
    }
}
