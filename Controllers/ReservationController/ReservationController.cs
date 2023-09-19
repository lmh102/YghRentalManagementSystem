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
        public ResponseDTO<List<GetListReservationDTO>> GetListReservationPedding(Guid OwnerId)
        {
            return _reservationService.GetAllReservationPendingByOwnerId(OwnerId);
        }
        [HttpGet("get-list-reservation-needpay")]
        public ResponseDTO<List<GetListReservationDTO>> GetListReservationNeedpay(Guid OwnerId)
        {
            return _reservationService.GetAllReservationNeedpayByOwnerId(OwnerId);
        }
        [HttpPost("accept-request-reservation")]
        public ResponseDTO<bool> AcceptRequestReservation(Guid OwnerId, int ReservationId)
        {
            return _reservationService.AcceptRequest(OwnerId, ReservationId);
        }
        [HttpPost("accept-pay-reservation")]
        public ResponseDTO<bool> AcceptPayReservation(Guid OwnerId, int ReservationId)
        {
            return _reservationService.AcceptPay(OwnerId, ReservationId);
        }
    }
}
