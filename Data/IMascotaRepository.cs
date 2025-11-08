using System.Collections.Generic;
using PetCare.Models;


namespace PetCare.Data
{
    public interface IMascotaRepository
    {
        void AgregarMascota(Mascota mascota);
        IReadOnlyList<Mascota> ObtenerMascotas();
    }
}