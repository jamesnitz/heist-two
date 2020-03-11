using System;

namespace heist_two
{
  public class Muscle : IRobber
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public double PercentageCut { get; set; }
    public void PerformSkill(Bank Bank)
    {
      Bank.SecurityGuardScore -= SkillLevel;
      Console.WriteLine($"The muscle: {Name} is flexing on these guards. Security Guard Score decreased by : {SkillLevel}");
      if (Bank.SecurityGuardScore <= 0)
      {
        Console.WriteLine($"{Name} has defeated all guards. But they're not dead");
      }
    }
    public override string ToString()
    {
      return $"{Name} is a muscle person and has a skill level of {SkillLevel} and wants a {PercentageCut}% cut";
    }
  }
}