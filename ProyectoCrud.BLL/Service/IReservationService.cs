using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IReservationService
    {
        Task<bool> Insert(Reservation model);
        Task<bool> Update(Reservation model);
        Task<bool> Delete(int id);
        Task<Reservation> Get(int id);
        Task<IQueryable<Reservation>> GetAll();
        Task<Reservation> GetForDate(DateTime date);
    }
}
