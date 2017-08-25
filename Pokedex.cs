using System;
using System.Collections.Generic;


[Serializable]
public class Pokedex
{
    public List<Pokemon> Pokemon;

    public Pokedex()
    {
        Pokemon = new List<Pokemon>();
    }
}
