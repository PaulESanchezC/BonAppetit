using System.ComponentModel.DataAnnotations;
using Models.MessageQueueModels.PaymentSuccessMessageModels;

namespace Models.PaymentModels;

public class PaymentSuccess
{
    [Required]
    public PaymentCreate PaymentCreate { get; set; }

    [Required]
    public PaymentMessage PaymentMessage { get; set; }
}