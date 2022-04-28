using System.ComponentModel.DataAnnotations;
using Models.PaymentMessageModels;

namespace Models.PaymentModels;

public class PaymentSuccess
{
    [Required]
    public PaymentCreateVm PaymentCreate { get; set; }

    [Required]
    public PaymentMessage PaymentMessage { get; set; }
}