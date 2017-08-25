using System;
using System.Collections.Generic;


[Serializable]
public class Stats
{
    public string Attack;
    public string Defense;
    public string Stamina;
    public string Total;
    public string MaxCP;

    public Stats()
    {
        Attack = String.Empty;
        Defense = String.Empty;
        Stamina = String.Empty;
        Total = String.Empty;
        MaxCP = String.Empty;
    }
}
