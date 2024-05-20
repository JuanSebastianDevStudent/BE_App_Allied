using AutoMapper;
using BE_CRUD_App_Allied.Models.DTO;

namespace BE_CRUD_App_Allied.Models.Profiles
{
    public class Usuario_AlliedProfile :Profile
    {
        public Usuario_AlliedProfile()
        {
            CreateMap<Usuario_Allied, Usuario_AlliedDTO>();
            CreateMap<Usuario_AlliedDTO, Usuario_Allied>();
        }
    }
}
