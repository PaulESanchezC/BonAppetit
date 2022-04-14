namespace Models.EmailModels;

public class Email
{
    public string Recipient { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public string  Template { get; set; }
}