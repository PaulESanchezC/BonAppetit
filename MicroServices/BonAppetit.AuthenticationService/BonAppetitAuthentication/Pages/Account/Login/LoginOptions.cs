namespace IdentityServer.Pages.Account.Login
{
    public class LoginOptions
    {
        public static bool AllowLocalLogin = true;
        public static bool AllowRememberLogin = true;
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromMinutes(7);
        public static string InvalidCredentialsErrorMessage = "Invalid username or password";
    }
}