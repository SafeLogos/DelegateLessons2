namespace DelegateLessons2.Models
{
    public class UserModel
    {
        public UserModel(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }


    }
}
