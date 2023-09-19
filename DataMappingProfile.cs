using AutoMapper;
using YghRentalManagementSystem.DTO.ReservationDTO;
using YghRentalManagementSystem.Infra.Models;

namespace YghRentalManagementSystem
{
    public class DataMappingProfile : Profile
    {
        public DataMappingProfile()
        {
            CreateMap<Reservation, GetListReservationDTO>().ReverseMap();

        }
    }
}
