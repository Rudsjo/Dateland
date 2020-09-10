namespace Dateland.Test2.Core
{
    public interface IUser
    {
        int UserId { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
        string EmailAdress { get; set; }

        string ProfilePictureUrl { get; set; }
    }
}