using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Repository : MonoBehaviour 
{
    private static Repository _singleton = default(Repository);

    [SerializeField]
    private Pokedex _pokedex = default(Pokedex);

    public static Repository Singleton
    {
        get { return _singleton; }
    }
    public Pokedex Pokedex
    {
        get { return _pokedex; }
        set { _pokedex = value; }
    }

    private void Awake()
    {
        if (_singleton == null)
        {
            _singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_singleton != this)
        {
            GameObject.DestroyImmediate(gameObject);
        }
    }

    private void OnEnable()
    {
        TextAsset file = Resources.Load("Pokedex") as TextAsset;

        _pokedex = (!string.IsNullOrEmpty(file.text)) ? JsonUtility.FromJson<Pokedex>(file.text) : new Pokedex();
    }

    public Pokemon FindById(string id)
    {
        return Pokedex.Pokemon.FirstOrDefault(pokemon => pokemon.Id == id);
    }

    public Pokemon FindByName(string name)
    {
        return Pokedex.Pokemon.FirstOrDefault(pokemon => pokemon.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<Pokemon> FindByType(CombatType type)
    {
        return (from pokemon in Pokedex.Pokemon where pokemon.Types.Contains(type) select pokemon).ToList();
    }

    public List<Pokemon> FindByTypes(CombatType typeOne, CombatType typeTwo)
    {
        return (from pokemon in Pokedex.Pokemon where pokemon.Types.Contains(typeOne) || pokemon.Types.Contains(typeTwo) select pokemon).ToList();
    }

    public List<Pokemon> FindByExactTypes(CombatType typeOne, CombatType typeTwo)
    {
        return (from pokemon in Pokedex.Pokemon where pokemon.Types.Contains(typeOne) && pokemon.Types.Contains(typeTwo) select pokemon).ToList();
    }
}
