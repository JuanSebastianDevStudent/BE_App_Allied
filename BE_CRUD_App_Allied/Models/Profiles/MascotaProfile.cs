using AutoMapper;
using BE_CRUD_Mascotas.Models.DTO;

namespace BE_CRUD_Mascotas.Models.Profiles
{
    public class MascotaProfile :Profile
    {
        public MascotaProfile()
        {
            CreateMap<Mascota, MascotaDTO>();
            CreateMap<MascotaDTO, Mascota>();
        }
    }
}
