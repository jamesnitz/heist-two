using System;

namespace heist_two
  {
    public class Hacker : IRobber
    {
      public string Name { get; set; }
      public int SkillLevel { get; set; }
      public int PercentageCut { get; set; }
      public void PerformSkill(Bank Bank)
      {
        Bank.AlarmScore -= SkillLevel;
        Console.WriteLine($"The Hacker: {Name} is hacking the mainframe. Alarm Score decreased by : {SkillLevel}");
        if (Bank.AlarmScore <= 0)
        {
          Console.WriteLine($"{Name} has disabled the alarm");
        }

      }
    }
  }