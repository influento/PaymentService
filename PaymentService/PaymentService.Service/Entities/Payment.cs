namespace PaymentService.Service.Entities
{
    public class Payment
    {
        public string CustomerId { get; set; }

        public string Currency { get; set; }

        public int Amount { get; set; }
    }
}