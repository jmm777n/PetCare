using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PetCare.Models;


namespace PetCare.Data
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly List<Mascota> _mascotas = new();
        private readonly ReaderWriterLockSlim _lock = new();


        public void AgregarMascota(Mascota mascota)
        {
            _lock.EnterWriteLock();
            try
            {
                _mascotas.Add(mascota);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }


        public IReadOnlyList<Mascota> ObtenerMascotas()
        {
            _lock.EnterReadLock();
            try
            {
                return _mascotas
                .OrderByDescending(m => m.FechaIngreso)
                .ThenBy(m => m.Nombre)
                .ToList();
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
}