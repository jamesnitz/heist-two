using System;
using System.Collections.Generic;
using System.Linq;

namespace heist_two
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Heisters");
            List<IRobber> Rolodex = new List<IRobber>();
            Bank nationalBank = new Bank();

            var garrett = new Muscle()
            {
                Name = "Mr. Stale",
                SkillLevel = 75,
                PercentageCut = 10
            };
            var william = new Hacker()
            {
                Name = "Squillium",
                SkillLevel = 75,
                PercentageCut = 20
            };
            var kev = new LockSpecialist()
            {
                Name = "Kith Boy",
                SkillLevel = 100,
                PercentageCut = 25
            };
            var namita = new Muscle()
            {
                Name = "Ms. Manohar",
                SkillLevel = 100,
                PercentageCut = 25
            };

            var steve = new Hacker()
            {
                Name = "ChortleHoort",
                SkillLevel = 100,
                PercentageCut = 30
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
            //END OF BUILDER SECTION
            Dictionary<string, int> bankScores = new Dictionary<string, int>();
            Random randy = new Random();
            var alarmScore = randy.Next(0, 101);
            var vaultScore = randy.Next(0, 101);
            var securityGuardScore = randy.Next(0, 101);
            var cashOnHand = randy.Next(50000, 1000001);
            nationalBank.AlarmScore = alarmScore;
            nationalBank.VaultScore = vaultScore;
            nationalBank.SecurityGuardScore = securityGuardScore;
            nationalBank.CashOnHand = cashOnHand;

            bankScores.Add("alarm ", alarmScore);
            bankScores.Add("vault ", vaultScore);
            bankScores.Add("Security guard ", securityGuardScore);
            var orderedScores = bankScores.OrderBy(score => score.Value);
            var mostSecure = orderedScores.Last();
            var leastSecure = orderedScores.First();

            Console.WriteLine("------RECON REPORT------");
            Console.WriteLine($"Most secure is: {mostSecure.Key}.  Least secure is {leastSecure.Key}.");
            Console.WriteLine("---------------------------");
            //
            foreach (var mem in Rolodex)
            {
                Console.WriteLine($"{Rolodex.IndexOf(mem)} {mem.ToString()}");
            }
            List<IRobber> crew = new List<IRobber>();
            double totalTake = 100;
            while (true)
            {
                Console.WriteLine("Assemble your crew! Enter your Member #");
                var chosenMember = Console.ReadLine();
                if (chosenMember == "")
                {
                    break;
                }
                foreach (var item in Rolodex)
                {
                    if (int.Parse(chosenMember) == Rolodex.IndexOf(item))
                    {
                        crew.Add(item);
                        totalTake -= item.PercentageCut;
                        Console.WriteLine($"{totalTake} is left");
                        Rolodex.Remove(item);
                        break;
                    }
                }
                foreach (var mem in Rolodex)
                {
                    if (mem.PercentageCut < totalTake)
                    {
                        Console.WriteLine($"{Rolodex.IndexOf(mem)} {mem.ToString()}");
                    }
                }
            }
            Console.WriteLine("YOUR ASSEMBLED CREW IS");
            foreach (var item in crew)
            {
                Console.WriteLine($"{item.ToString()}");
            }
            Console.WriteLine("---------");
            foreach (var crewMember in crew)
            {
                crewMember.PerformSkill(nationalBank);
                if (nationalBank.IsSecure == true)
                {
                    Console.WriteLine($"{crewMember.Name} failed!");
                }
                else
                {
                    Console.WriteLine($"You Did it");
                    double totalMemberEarnings = 0;
                    foreach (var memby in crew)
                    {
                        var memberEarnings = (memby.PercentageCut / 100) * nationalBank.CashOnHand;
                        totalMemberEarnings += memberEarnings;
                        Console.WriteLine($"{memby.Name} earned {memberEarnings.ToString("C")}");
                    }
                    Console.WriteLine($"{nationalBank.CashOnHand}");
                    double myCash = nationalBank.CashOnHand - totalMemberEarnings;
                    Console.WriteLine($"The mastermind earned {myCash.ToString("C")}");
                }
            }

        }
    }
}