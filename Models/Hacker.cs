using System;

namespace heist_two
{
  public class Hacker : IRobber
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double PercentageCut { get; set; }
    public void PerformSkill(Bank Bank)
    {
      Bank.AlarmScore -= SkillLevel;
      Console.WriteLine($"The Hacker: {Name} is hacking the mainframe. Alarm Score decreased by : {SkillLevel}");
      if (Bank.AlarmScore <= 0)
      {
        Console.WriteLine($"{Name} has disabled the alarm");
      }

    }
    public override string ToString()
    {
      return $"{Name} is a hacker and has a skill level of {SkillLevel} and wants a {PercentageCut}% cut";
    }
  }
}