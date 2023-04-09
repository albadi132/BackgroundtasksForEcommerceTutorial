namespace BackgroundtasksForEcommerceTutorial.Models
{
    public class User
    {
        public string Name { get; set; } = Faker.Name.FullName();

        public string Email { get; set; } = Faker.Internet.Email();
    }
}
