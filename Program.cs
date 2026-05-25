using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonAssignment
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public override string ToString() => $"{Name}, {Age}, {City}";
    }

    // Task 4: inheritance – Admin and RegularUser
    public class Admin : User
    {
        public string AdminLevel { get; set; }
        public string[] Permissions { get; set; }
        public override string ToString() => base.ToString() + $", Admin: {AdminLevel}, [{string.Join(",", Permissions)}]";
    }

    public class RegularUser : User
    {
        public int LoyaltyPoints { get; set; }
        public override string ToString() => base.ToString() + $", Loyalty: {LoyaltyPoints}";
    }

    class Program
    {
        static void Main()
        {
            string filePath = "users.json";
            string json = File.ReadAllText(filePath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            Console.WriteLine("=== Initial users ===");
            foreach (var u in users)
                Console.WriteLine(u);

            // Task 2: add new user
            users.Add(new User { Name = "Alice Brown", Age = 28, City = "Chicago" });
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

            Console.WriteLine("\n=== After adding Alice Brown ===");
            foreach (var u in users)
                Console.WriteLine(u);
        }
    }
}