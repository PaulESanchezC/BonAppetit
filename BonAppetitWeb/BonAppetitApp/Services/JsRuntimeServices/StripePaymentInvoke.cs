using Microsoft.JSInterop;

namespace Services.JsRuntimeServices;

public static class StripePaymentInvoke
{
    public static async ValueTask StripePayment(this IJSRuntime js, string sessionId)
    {
        await js.InvokeVoidAsync("stripeCheckout", sessionId);
    }
}