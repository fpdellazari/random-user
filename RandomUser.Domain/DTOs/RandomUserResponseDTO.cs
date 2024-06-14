namespace RandomUser.Domain.DTOs {
    public class RandomUserResponseDTO {
        public required IEnumerable<UserDTO> Results { get; set; }
    }
}
