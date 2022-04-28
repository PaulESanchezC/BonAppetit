﻿using Models.EmailModels;
using Models.PaymentModels;
using Models.ReservationModels;

namespace Models.PaymentMessageModels;

public class PaymentSuccessMessage
{
    public ReservationCreate ReservationCreate { get; set; }
    public PaymentDto Payment { get; set; }
    public List<Email> Emails { get; set; }
}