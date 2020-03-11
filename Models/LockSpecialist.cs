using System;

namespace heist_two
{
  public class LockSpecialist : IRobber
  {
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(Bank Bank)
    {
      Bank.VaultScore -= SkillLevel;
      Console.WriteLine($"The Lock specialist: {Name} cracking the codes. Vault Score decreased by : {SkillLevel}");
      if (Bank.VaultScore <= 0)
      {
        Console.WriteLine($"{Name} has opened the Vault");
      }

    }
    public override string ToString()
    {
      return $"{Name} is a lock wizz and has a skill level of {SkillLevel} and wants a {PercentageCut}% cut";
    }

  }
}