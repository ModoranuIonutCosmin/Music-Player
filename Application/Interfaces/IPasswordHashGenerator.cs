namespace Application.Interfaces
{
    public interface IPasswordHashGenerator
    {
        string HashPassword(string password);
    }
}