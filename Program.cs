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

    class Program
    {
        static void Main()
        {
            string filePath = "users.json";
            string json = File.ReadAllText(filePath);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);

            Console.WriteLine("=== Users from users.json ===");
            foreach (var u in users)
                Console.WriteLine(u);
        }
    }
}