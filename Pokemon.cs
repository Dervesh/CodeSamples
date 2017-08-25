using System;
using System.Collections.Generic;


[Serializable]
public class Pokemon
{
    public string Id;
    public string Name;
    public Stats Stats;
    public List<CombatType> Types;

    public Pokemon()
    {
        Id = String.Empty;
        Name = String.Empty;
        Stats = new Stats();
        Types = new List<CombatType>();
    }
}
