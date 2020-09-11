using System;

namespace Dateland.Test2.Core
{
    public interface IUser
    {
        City City { get; set; }
        int CityID { get; set; }
        DateTime DateOfBirth { get; set; }
        string Description { get; set; }
        Education Education { get; set; }
        int EducationID { get; set; }
        string Email { get; set; }
        int EmailConfirmed { get; set; }
        string FirstName { get; set; }
        Food Food { get; set; }
        int FoodID { get; set; }
        Gender Gender { get; set; }
        int GenderID { get; set; }
        GenderPreferation GenderPreferation { get; set; }
        int GenderPreferationID { get; set; }
        Interest Interest { get; set; }
        int InterestID { get; set; }
        bool IsEmailConfirmed { get; }
        string LastName { get; set; }
        Movie Movie { get; set; }
        int MovieID { get; set; }
        Music Music { get; set; }
        int MusicID { get; set; }
        string PasswordHash { get; set; }
        Profession Profession { get; set; }
        int ProfessionID { get; set; }
        string ProfilePictureUrl { get; set; }
        Relation Relation { get; set; }
        int RelationID { get; set; }
        string Salt { get; set; }
        int UserID { get; set; }
    }
}