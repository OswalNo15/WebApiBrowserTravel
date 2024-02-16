using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class ReservationRepository : IGenericRepository<Reservation>
    {
        private readonly BdMilesCarRentalContext _context;
        //constructor
        public ReservationRepository(BdMilesCarRentalContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            Reservation model = _context.Reservations.First(c => c.IdReservation == id);
            _context.Reservations.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Reservation> Get(int id)
        {
            return await _context.Reservations.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IQueryable<Reservation>> GetAll()
        {
            IQueryable<Reservation> queryContratoSQL = _context.Reservations;
            return queryContratoSQL;
        }

        public async Task<bool> Insert(Reservation model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Reservation model)
        {
            _context.Reservations.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
