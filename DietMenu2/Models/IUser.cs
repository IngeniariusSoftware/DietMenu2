
namespace DietMenu2.Models
{
    public interface IUser
    {
        int Id { get; set; }

        string Login { get; set; }

        string Hash { get; set; }

        string Password { get; set; }

        string Name { get; set; }

        string Surname { get; set; }

        string Weight { get; set; }

        string Height { get; set; }

        string Age { get; set; }

        string GenderId { get; set; }

        double GetUnformattedWeight { get; }

        double GetUnformattedHeight { get; }

        int GetUnformattedAge { get; }

        int GetUnformattedGenderId { get; }

        string FullName { get; }

        int TypeId { get; }

        int EntityId { get; }
    }
}
