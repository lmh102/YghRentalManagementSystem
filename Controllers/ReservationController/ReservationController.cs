using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YghRentalManagementSystem.DTO.Common;
using YghRentalManagementSystem.DTO.ReservationDTO;
using YghRentalManagementSystem.Services.IReservationServices;

namespace YghRentalManagementSystem.Controllers.ReservationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;
        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }
        [HttpGet("get-list-reservation-pendding")]
        public ResponseDTO<List<GetListReservationDTO>> GetListReservationPedding(string OwnerId)
        {
            return _reservationService.GetAllReservationPendingByOwnerId(OwnerId);
        }
        [HttpGet("get-list-reservation-needpay")]
        public ResponseDTO<List<GetListReservationDTO>> GetListReservationNeedpay(string OwnerId)
        {
            return _reservationService.GetAllReservationNeedpayByOwnerId(OwnerId);
        }
        [HttpGet("get-list-reservation-accepted")]
        public ResponseDTO<List<GetListReservationDTO>> GetListReservationAccept(string OwnerId)
        {
            return _reservationService.GetAllReservationAcceptedByOwnerId(OwnerId);
        }
        [HttpPost("accept-request-reservation")]
        public ResponseDTO<bool> AcceptRequestReservation(string OwnerId, int ReservationId)
        {
            return _reservationService.AcceptRequest(OwnerId, ReservationId);
        }
        [HttpPost("accept-pay-reservation")]
        public ResponseDTO<bool> AcceptPayReservation(string OwnerId, int ReservationId)
        {
            return _reservationService.AcceptPay(OwnerId, ReservationId);
        }
        [HttpPost("reject-request-reservation")]
        public ResponseDTO<bool> RejectRequestReservation(string OwnerId, int ReservationId)
        {
            return _reservationService.RejectRequest(OwnerId, ReservationId);
        }
    }
}
