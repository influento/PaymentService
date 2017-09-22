using PaymentService.Service.Utils.Extensions;

namespace PaymentService.Service.ViewModels.Request.CardVM
{
    public class CardRequestVM : IRequestValidator
    {
        public string Number { get; set; }

        public string CVC { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

        public bool IsValid()
        {
            return Number.IsCardNumber() &&
                   CVC.Length == 3 &&
                   (ExpirationMonth >= 1 && ExpirationMonth <= 12) &&
                   ExpirationYear.ToString().Length == 2;
        }
    }
}