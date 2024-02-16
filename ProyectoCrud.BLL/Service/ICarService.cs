using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    internal interface ICarService
    {
        Task<bool> Insert(Car model);
        Task<bool> Update(Car model);
        Task<bool> Delete(int id);
        Task<Car> Get(int id);
        Task<IQueryable<Car>> GetAll();
        Task<IQueryable<Car>> GetForColor(string color);
        Task<IQueryable<Car>> GetForModel(int? year);
    }
}
