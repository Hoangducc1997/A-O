using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

[CreateAssetMenu]
public class CharactersDatabase : ScriptableObject
{

    [SerializeField] Character[] characters;

    public int CharactersCount
    {
        get
        {
            return characters.Length;
        }
    }
    public Character GetCharacters(int index)
    {
        return characters[index];
    }

    public Character GetCharacterByID (int characterID)
    {
        for(int index = 0; index < characters.Length; index ++)
        {
            if(characters[index] != null)
            {
                if (characters[index].characterID == characterID) return characters[index];
            }
        }
        return null;
    }

    public List<Character> getCharacterList()
    {
        return characters.ToList();
    }
}
    