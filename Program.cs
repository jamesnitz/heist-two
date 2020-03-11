using System;
using System.Collections.Generic;

namespace heist_two
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Heisters");
            List<IRobber> Rolodex = new List<IRobber>();
            var garrett = new Muscle()
            {
                Name = "Mr. Stale",
                SkillLevel = 50,
                PercentageCut = 10
            };
            var william = new Hacker()
            {
                Name = "Squillium",
                SkillLevel = 25,
                PercentageCut = 20
            };
            var kev = new LockSpecialist()
            {
                Name = "Kith Boy",
                SkillLevel = 35,
                PercentageCut = 25
            };
            var namita = new Muscle()
            {
                Name = "Ms. Manohar",
                SkillLevel = 35,
                PercentageCut = 25
            };

            var steve = new Hacker()
            {
                Name = "ChortleHoort",
                SkillLevel = 85,
                PercentageCut = 40
            };

            Rolodex.Add(garrett);
            Rolodex.Add(steve);
            Rolodex.Add(namita);
            Rolodex.Add(william);
            Rolodex.Add(kev);

            Console.WriteLine($"The Rolex currently has {Rolodex.Count} Heistees!");
            while (true)
            {
                Console.WriteLine($"Please add a new crew memby name");
                var userInputName = Console.ReadLine();
                if (userInputName == "")
                {
                    break;
                }
                while (true)
                {
                    Console.WriteLine($"What is {userInputName}'s specialty: hacker, muscle, or lock specialist?");
                    var userInputSpeciality = Console.ReadLine();
                    if (userInputSpeciality.ToLower() == "muscle")
                    {
                        Muscle newMuscle = new Muscle()
                        {
                        Name = userInputName,
                        };
                        Console.WriteLine("What's their skill level?");
                        var userSkill = Console.ReadLine();
                        newMuscle.SkillLevel = int.Parse(userSkill);
                        Console.WriteLine("What's their take on this score?");
                        var userPercentageCut = Console.ReadLine();
                        newMuscle.PercentageCut = int.Parse(userPercentageCut);
                        Rolodex.Add(newMuscle);
                        break;
                    }
                    else if (userInputSpeciality.ToLower() == "hacker")
                    {
                        Hacker newHacker = new Hacker()
                        {
                        Name = userInputName,
                        };
                        Console.WriteLine("What's their skill level?");
                        var userSkill = Console.ReadLine();
                        newHacker.SkillLevel = int.Parse(userSkill);
                        Console.WriteLine("What's their take on this score?");
                        var userPercentageCut = Console.ReadLine();
                        newHacker.PercentageCut = int.Parse(userPercentageCut);
                        Rolodex.Add(newHacker);
                        break;
                    }
                    else if (userInputSpeciality.ToLower() == "lock specialist")
                    {
                        LockSpecialist newLockSpecialist = new LockSpecialist()
                        {
                        Name = userInputName,
                        };
                        Console.WriteLine("What's their skill level?");
                        var userSkill = Console.ReadLine();
                        newLockSpecialist.SkillLevel = int.Parse(userSkill);
                        Console.WriteLine("What's their take on this score?");
                        var userPercentageCut = Console.ReadLine();
                        newLockSpecialist.PercentageCut = int.Parse(userPercentageCut);
                        Rolodex.Add(newLockSpecialist);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"{userInputSpeciality} is not a speciality. Please enter a valid specialty.");

                    }

                }
            }
        }
    }
}