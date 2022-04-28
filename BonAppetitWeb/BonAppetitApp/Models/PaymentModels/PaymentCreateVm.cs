﻿using System.ComponentModel.DataAnnotations;

namespace Models.PaymentModels;

public class PaymentCreateVm
{
    #region Payment properties

    [Required]
    public string RestaurantId { get; set; }

    [Required]
    public string TableId { get; set; }

    [Required]
    public string ApplicationUserId { get; set; }
    [Required]
    public double RestaurantReservationFee { get; set; }

    [Required]
    public double BonAppetitFee { get; set; }

    [Required]
    public double ProvincialTaxes { get; set; }

    [Required]
    public double FederalTaxes { get; set; }

    [Required]
    public double Amount { get; set; }

    [Required]
    public string SessionId { get; set; }

    #endregion
}