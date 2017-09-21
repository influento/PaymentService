namespace PaymentService.Service.ViewModels.Request.PaymentVM
{
    public class RegularPaymentsRequestVM : IRequestValidator
    {
        public string CustomerId { get; set; }

        public string Currency { get; set; }

        public int Amount { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(CustomerId) &&
                   Currency.Length == 3 &&
                   Amount > 0;
        } 
    }
}
