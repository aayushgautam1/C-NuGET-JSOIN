using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonAssignment
{
    // Base User class (Task 1, 2, 3)
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public override string ToString() => $"{Name}, {Age}, {City}";
    }

    // Task 4: Inheritance – Admin and RegularUser
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
            // ----------------------------------------------
            // Task 1 & 3: read manual JSON, deserialize, loop
            // ----------------------------------------------
            string filePath = "users.json";
            string json = File.ReadAllText(filePath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            Console.WriteLine("=== Task 1&3: Initial users from users.json ===");
            foreach (var u in users)
                Console.WriteLine(u);

            // ----------------------------------------------
            // Task 2: Add new entry to JSON object
            // ----------------------------------------------
            users.Add(new User { Name = "Alice Brown", Age = 28, City = "Chicago" });
            string updatedJson = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

            Console.WriteLine("\n=== Task 2: After adding Alice Brown ===");
            foreach (var u in users)
                Console.WriteLine(u);

           
            // Task 5: Create new JSON file with Admin and RegularUser
            //         (using inheritance from Task 4)
           
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            var specialList = new List<User>
            {
                new Admin { Name = "SuperAdmin", Age = 40, City = "Seattle", AdminLevel = "Super", Permissions = new[] { "read", "write" } },
                new RegularUser { Name = "RegularBob", Age = 22, City = "Boston", LoyaltyPoints = 150 }
            };

            string specialFile = "specialized_users.json";
            File.WriteAllText(specialFile, JsonConvert.SerializeObject(specialList, settings));

            List<User> loaded = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(specialFile), settings);
            Console.WriteLine("\n=== Task 5: Data from specialized_users.json ===");
            foreach (var u in loaded)
                Console.WriteLine(u);
        }
    }
}