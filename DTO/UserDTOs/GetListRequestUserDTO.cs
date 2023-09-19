namespace YghRentalManagementSystem.DTO.UserDTOs
{
    public class GetListRequestUserDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
