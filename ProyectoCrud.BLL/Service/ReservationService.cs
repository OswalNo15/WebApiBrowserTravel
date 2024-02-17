using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class ReservationService : IReservationService
    {
        private readonly IGenericRepository<Reservation> _reservationService;
        public ReservationService(IGenericRepository<Reservation> reservationService)
        {
            _reservationService = reservationService;
        }
        public async Task<bool> Delete(int id)
        {
            return await _reservationService.Delete(id);
        }

        public async Task<Reservation> Get(int id)
        {
            return await _reservationService.Get(id);
        }

        public async Task<IQueryable<Reservation>> GetAll()
        {
            return await _reservationService.GetAll();   
        }

        public async Task<Reservation> GetForDate(DateTime date)
        {
            IQueryable<Reservation> queryReservationSQL = await _reservationService.GetAll();
            Reservation dateReservation = queryReservationSQL.FirstOrDefault(x => x.DateReservation.Equals(date));
            if (dateReservation == null) throw new ArgumentNullException("Reservation not found");
            return dateReservation;
        }

        public async Task<bool> Insert(Reservation model)
        {
            return await _reservationService.Insert(model);
        }

        public async Task<bool> Update(Reservation model)
        {
            return await _reservationService.Update(model);
        }
    }
}
