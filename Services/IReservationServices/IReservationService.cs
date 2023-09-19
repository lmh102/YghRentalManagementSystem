using AutoMapper;
using YghRentalManagementSystem.DTO.Common;
using YghRentalManagementSystem.DTO.ReservationDTO;
using YghRentalManagementSystem.Infra;
using YghRentalManagementSystem.Infra.Enums;

namespace YghRentalManagementSystem.Services.IReservationServices
{
    public interface IReservationService
    {
        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationPendingByOwnerId(Guid UserId);
        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationNeedpayByOwnerId(Guid UserId);
        public ResponseDTO<bool> AcceptRequest(Guid UserId, int ReservationId);
        public ResponseDTO<bool> AcceptPay(Guid UserId, int ReservationId);
    }
    public class ReservationService : IReservationService
    {
        private readonly RentalManagementContext _context;
        private readonly IMapper _mapper;
        public ReservationService(RentalManagementContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ResponseDTO<bool> AcceptPay(Guid UserId, int ReservationId)
        {
            var reservation = _context.Reservations.FirstOrDefault(e => e.Id == ReservationId);
            if(reservation == null)
            {
                return new ResponseDTO<bool>(200, "Reservation Not Found");
            }
            reservation.Status = (int)ReservationStatus.Accepted;
            _context.SaveChanges();
            return new ResponseDTO<bool>(true);
        }

        public ResponseDTO<bool> AcceptRequest(Guid UserId, int ReservationId)
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

        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationNeedpayByOwnerId(Guid UserId)
        {
            var ListReservation = _context.Reservations.Where(e => e.OwnerId == UserId && e.Status == (int) ReservationStatus.NeedPay)
                                                       .Select(e => _mapper.Map<GetListReservationDTO>(e))
                                                       .ToList();
            return new ResponseDTO<List<GetListReservationDTO>>()
            {
                Code = (int)RESPONSE_CODE.OK,
                Data = ListReservation
            };
        }

        public ResponseDTO<List<GetListReservationDTO>> GetAllReservationPendingByOwnerId(Guid UserId)
        {
            var ListReservation = _context.Reservations.Where(e => e.OwnerId == UserId && e.Status == (int)ReservationStatus.Pending)
                                                       .Select(e => _mapper.Map<GetListReservationDTO>(e))
                                                       .ToList();
            return new ResponseDTO<List<GetListReservationDTO>>()
            {
                Code = (int)RESPONSE_CODE.OK,
                Data = ListReservation
            };
        }
    }
}
