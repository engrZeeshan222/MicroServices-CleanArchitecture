namespace Clean.Application
{
    public class ChargeResponseDTO
    {
        public string ChargeId { get; set; }
        public string Currency { get; set; }
        public long Amount { get; set; }
        public string CustomerId { get; set; }
        public string ReceiptEmail { get; set; }
        public string Description { get; set; }
    }
}
