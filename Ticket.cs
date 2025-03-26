using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketHubApi
{
    public class Ticket
    {
        [JsonPropertyName("concertId")]
        public int ConcertId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("creditCard")]
        public string CreditCard { get; set; } = string.Empty;

        [JsonPropertyName("expiration")]
        public string Expiration { get; set; } = string.Empty;

        [JsonPropertyName("securityCode")]
        public string SecurityCode { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("province")]
        public string Province { get; set; } = string.Empty;

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;
    }
}
