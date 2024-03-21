using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopsManager : MonoBehaviour
{
    //Characters
    public CharactersDatabase charactersDB;
    public Text nameCharactersText;
    public Image imageCharacters;
    private int selectedCharactersOption = 0;

    //Maps
    public MapsDatabase mapsDB;
    public Text nameMapsText;
    public Image imageMaps;
    private int selectedMapsOption = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectOption"))
        {
            selectedCharactersOption = 0;
        }
        else
        {
            LoadCharacters();
        }
        UpdateCharacter(selectedCharactersOption);

        if (!PlayerPrefs.HasKey("selectedMapOption"))
        {
            selectedMapsOption = 0;
        }
        else
        {
            LoadMaps();
        }
        UpdateMap(selectedMapsOption);
    }
    public void NextOptionCharacter()
    {
        selectedCharactersOption++;
        if(selectedCharactersOption >= charactersDB.CharactersCount)
        {
            selectedCharactersOption = 0;
        }
        UpdateCharacter(selectedCharactersOption);
        SaveCharacters();
    }
    public void BackOptionCharacter()
    {
        selectedCharactersOption--;
        if(selectedCharactersOption < 0)
        {
            selectedCharactersOption = charactersDB.CharactersCount - 1;
        }
        UpdateCharacter(selectedCharactersOption);
        SaveCharacters();
    }
    private void UpdateCharacter(int selectedCharactersOption)
    {
        Character characters = charactersDB.GetCharacters(selectedCharactersOption);
        //SpriteRenderer characterRenderer = characters.charactersPrefab.GetComponent<SpriteRenderer>();
        //if (characterRenderer != null)
        //{
        //    imageCharacters.sprite = characterRenderer.sprite;
        //}
        //else
        //{
        //    Debug.LogWarning("SpriteRenderer not found on characterPrefab.");
        //}
        nameCharactersText.text = characters.characterName;
    }

    private void LoadCharacters()
    {
        selectedCharactersOption = PlayerPrefs.GetInt("selectOption");
    }
    private void SaveCharacters()
    {
        PlayerPrefs.SetInt("selectOption", selectedCharactersOption);
    }


    public void NextOptionMap()
    {
        selectedMapsOption++;
        if (selectedMapsOption >= mapsDB.MapsCount)
        {
            selectedMapsOption = 0;
        }
        UpdateMap(selectedMapsOption);
        SaveMaps();
    }

    public void BackOptionMap()
    {
        selectedMapsOption--;
        if (selectedMapsOption < 0)
        {
            selectedMapsOption = mapsDB.MapsCount - 1;
        }
        UpdateMap(selectedMapsOption);
        SaveMaps();
    }

    private void UpdateMap(int selectedMapsOption)
    {
        Maps map = mapsDB.GetMaps(selectedMapsOption);
        //SpriteRenderer mapRenderer = map.mapsPrefab.GetComponent<SpriteRenderer>();
        //if (mapRenderer != null)
        //{
        //    imageMaps.sprite = mapRenderer.sprite;
        //}
        //else
        //{
        //    Debug.LogWarning("SpriteRenderer not found on mapPrefab.");
        //}
        nameMapsText.text = map.mapsName;
    }

    private void LoadMaps()
    {
        selectedMapsOption = PlayerPrefs.GetInt("selectedMapOption");
    }

    private void SaveMaps()
    {
        PlayerPrefs.SetInt("selectedMapOption", selectedMapsOption);
    }
}
