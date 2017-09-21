using PaymentService.Service.Utils.Extensions;
using PaymentService.Service.ViewModels.Request.CardVM;

namespace PaymentService.Service.ViewModels.Request.PaymentVM
{
    public class OneTimePaymentRequestVM : IRequestValidator
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Currency { get; set; }

        public int Amount { get; set; }

        public CardRequestVM Card { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   Email.IsEmail() &&
                   Card.IsValid() &&
                   Currency.Length == 3 &&
                   Amount > 0;
        }
    }
}
