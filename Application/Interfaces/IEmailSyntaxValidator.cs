namespace Application.Interfaces;

public interface IEmailSyntaxValidator
{
    bool IsEmailValid(string email);
}
