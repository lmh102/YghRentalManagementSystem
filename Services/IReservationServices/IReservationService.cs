using AutoMapper;
using YghRentalManagementSystem.DTO.AccommodationDTOs;
using YghRentalManagementSystem.DTO.ApartmentDTOs;
using YghRentalManagementSystem.DTO.Common;
using YghRentalManagementSystem.DTO.ReservationDTO;
using YghRentalManagementSystem.DTO.UserDTOs;
using YghRentalManagementSystem.Infra;
using YghRentalManagementSystem.Infra.Enums;

namespace YghRentalManagementSystem.Services.IReservationServices
{
    public interface IReservationService
    {
        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationPendingByOwnerId(string UserId);
        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationNeedpayByOwnerId(string UserId);
        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationAcceptedByOwnerId(string UserId);
        public ResponseDTO<bool> AcceptRequest(string UserId, int ReservationId);
        public ResponseDTO<bool> AcceptPay(string UserId, int ReservationId);
        public ResponseDTO<bool> RejectRequest(string UserId, int ReservationId);
    }
    public class ReservationService : IReservationService
    {
        private readonly RentalManagementContext _context;
        private readonly IMapper _mapper;
        public ReservationService(RentalManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResponseDTO<bool> AcceptPay(string UserId, int ReservationId)
        {
            var reservation = _context.Reservations.FirstOrDefault(e => e.Id == ReservationId);
            if (reservation == null)
            {
                return new ResponseDTO<bool>(200, "Reservation Not Found");
            }
            reservation.Status = (int)ReservationStatus.Accepted;
            _context.SaveChanges();
            return new ResponseDTO<bool>(true);
        }

        public ResponseDTO<bool> AcceptRequest(string UserId, int ReservationId)
        {
            var reservation = _context.Reservations.FirstOrDefault(e => e.Id == ReservationId);
            if (reservation == null)
            {
                return new ResponseDTO<bool>(200, "Reservation Not Found");
            }
            reservation.Status = (int)ReservationStatus.NeedPay;
            _context.SaveChanges();
            return new ResponseDTO<bool>(true);
        }

        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationAcceptedByOwnerId(string UserId)
        {
            var listReservation = _context.Reservations.Where(e => e.OwnerId == UserId && e.Status == (int)ReservationStatus.Accepted)
                                                       .Select(e => _mapper.Map<GetListReservationDTO>(e))
                                                       .ToList();
            var result = listReservation.Select(reservation =>
            {
                var user = _context.Users.FirstOrDefault(user => user.UserId == reservation.UserId);

                reservation.Tenant = new GetListRequestUserDTO
                {
                    UserId = reservation.UserId,
                    Name = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    AvatarUrl = null
                };
                var apartment = _context.Apartments.FirstOrDefault(e => e.Id == reservation.ApartmentId);
                var accommodation = _context.Accommondations.FirstOrDefault(e => e.Id == apartment.AccommondationId);
                reservation.Accommodation = new GetListRequestAccommodationDTO
                {
                    Id = accommodation.Id,
                    Title = accommodation.Title,
                    Apartment = new GetListRequestApartmentDTO
                    {
                        ApartmentId = apartment.Id,
                        ApartmentName = apartment.Name
                    }
                };
                return reservation;
            }).ToList();
            return new ResponseDTO<List<GetListReservationDTO>>()
            {
                Code = (int)RESPONSE_CODE.OK,
                Data = result
            };
        }

        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationNeedpayByOwnerId(string UserId)
        {
            var listReservation = _context.Reservations.Where(e => e.OwnerId == UserId && e.Status == (int)ReservationStatus.NeedPay)
                                                       .Select(e => _mapper.Map<GetListReservationDTO>(e))
                                                       .ToList();
            var result = listReservation.Select(reservation =>
            {
                var user = _context.Users.FirstOrDefault(user => user.UserId == reservation.UserId);

                reservation.Tenant = new GetListRequestUserDTO
                {
                    UserId = reservation.UserId,
                    Name = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    AvatarUrl = null
                };
                var apartment = _context.Apartments.FirstOrDefault(e => e.Id == reservation.ApartmentId);
                var accommodation = _context.Accommondations.FirstOrDefault(e => e.Id == apartment.AccommondationId);
                reservation.Accommodation = new GetListRequestAccommodationDTO
                {
                    Id = accommodation.Id,
                    Title = accommodation.Title,
                    Apartment = new GetListRequestApartmentDTO
                    {
                        ApartmentId = apartment.Id,
                        ApartmentName = apartment.Name
                    }
                };
                return reservation;
            }).ToList();
            return new ResponseDTO<List<GetListReservationDTO>>()
            {
                Code = (int)RESPONSE_CODE.OK,
                Data = result
            };
        }

        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationPendingByOwnerId(string UserId)
        {
            var listReservation = _context.Reservations.Where(e => e.OwnerId == UserId && e.Status == (int)ReservationStatus.Pending)
                                                       .Select(e => _mapper.Map<GetListReservationDTO>(e))
                                                       .ToList();
            var result = listReservation.Select(reservation =>
            {
                var user = _context.Users.FirstOrDefault(user => user.UserId == reservation.UserId);

                reservation.Tenant = new GetListRequestUserDTO
                {
                    UserId = reservation.UserId,
                    Name = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    AvatarUrl = null
                };
                var apartment = _context.Apartments.FirstOrDefault(e => e.Id == reservation.ApartmentId);
                var accommodation = _context.Accommondations.FirstOrDefault(e => e.Id == apartment.AccommondationId);
                reservation.Accommodation = new GetListRequestAccommodationDTO
                {
                    Id = accommodation.Id,
                    Title = accommodation.Title,
                    Apartment = new GetListRequestApartmentDTO
                    {
                        ApartmentId = apartment.Id,
                        ApartmentName = apartment.Name
                    }
                };
                return reservation;
            }).ToList();
            return new ResponseDTO<List<GetListReservationDTO>>()
            {
                Code = (int)RESPONSE_CODE.OK,
                Data = result
            };
        }

        public ResponseDTO<bool> RejectRequest(string UserId, int ReservationId)
        {
            var reservation = _context.Reservations.FirstOrDefault(e => e.Id == ReservationId);
            if (reservation == null)
            {
                return new ResponseDTO<bool>(200, "Reservation Not Found");
            }
            reservation.Status = (int)ReservationStatus.Rejected;
            _context.SaveChanges();
            return new ResponseDTO<bool>(true);
        }
    }
}
