using PaymentService.Service.Utils.Extensions;
using PaymentService.Service.ViewModels.Request.CardVM;

namespace PaymentService.Service.ViewModels.Request.CustomerVM
{
    public class UpdateCustomerRequestVM : IRequestValidator
    {
        public string CustomerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public CardRequestVM Card { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(CustomerId) &&
                   !string.IsNullOrWhiteSpace(Name) &&
                   Email.IsEmail() &&
                   Card.IsValid();
        }
    }
}