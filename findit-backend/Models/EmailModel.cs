namespace findit_backend.Models;

public class EmailModel
{
    EmailModel(string to, string subject, string body) {
        this.To = to; 
        this.Subject = subject; 
        this.Body = body;
    }

    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
