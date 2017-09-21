namespace PaymentService.Service.Entities
{
    public class Card
    {
        public string Number { get; set; }
        
        public string Cvc { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }
    }
}
