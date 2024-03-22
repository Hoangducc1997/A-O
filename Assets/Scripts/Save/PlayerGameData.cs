using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerGameData : MonoBehaviour
{
    private static PlayerGameData _instance;

    // Public property to access the singleton instance
    public static PlayerGameData Instance
    {
        get { return _instance; }
        set { _instance = value; }
    }
    PlayerData playerData = new PlayerData();
    public PlayerData PlayerData
    {
        get { return playerData; }
        set { playerData = value; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this; // Assign the singleton instance to this
            DontDestroyOnLoad(gameObject); // Optional if you want the object to persist between scenes
            SaveManager.Load();
        }
    }

    public PlayerData newPlayerData()
    {
        PlayerData newplayer = new PlayerData
        {
            totalDiamond = 0,
            musicVolumeMenu = 1f,
            musicVolumeLevel = 1f,
            sfxVolume = 1f,
            currentCharacter = DefaultData.characterid,
            mapcurrentUnlock = DefaultData.Map,
            listCharacterID = new List<int>(),
            ListMap = new List<int>(),
        };
        playerData = newplayer;

        return newplayer;

    }
    public PlayerGameData(float musicMenu, float musicLevel, float sfx, List<int> characterList = null, List<int> MapList = null)
    {
        playerData.musicVolumeMenu = musicMenu;
        playerData.musicVolumeLevel = musicLevel;
        playerData.sfxVolume = sfx;
        if (characterList != null)
        {
            playerData.listCharacterID = characterList;
        }

        if (MapList != null)
        {
            playerData.ListMap = MapList;
        }
    }

    public void AddNewMap(int mapID)
    {
        if (!playerData.ListMap.Contains(mapID))
        {
            playerData.ListMap.Add(mapID);
        }
        SaveManager.Save(playerData);
    }

    public void AddNewCharacter(int characterID)
    {
        if (!playerData.listCharacterID.Contains(characterID))
        {
            playerData.listCharacterID.Add(characterID);
        }
        SaveManager.Save(playerData);
    }

    public void AddDimond(int valueAdd)
    {
        playerData.totalDiamond += valueAdd;
        SaveManager.Save(playerData);
    }

    public void RemoveDimond(int valueRemove)
    {
        playerData.totalDiamond -= valueRemove;
        SaveManager.Save(playerData);
    }
    //public void ResetAllData()
    //{
    //    SaveManager.DeleteSaveData(); // Xóa dữ liệu 
    //}

    public void UseNewCharacter(int characterId)
    {
        playerData.currentCharacter = characterId;
        SaveManager.Save(playerData);
    }
}

public class DefaultData
{
    public const int characterid = 0;
    public const int Diamond = 0;
    public const float musicVolumeMenu = 1f;
    public const float musicVolumeLevel = 1f;
    public const float sfxVolume = 1f;
    public const int Map = 1;
}

[Serializable]
public class PlayerData
{
    // Your player data fields here...
    public int totalDiamond;
    public float musicVolumeMenu;
    public float musicVolumeLevel;
    public float sfxVolume;
    public int currentCharacter;
    public int mapcurrentUnlock;
    public List<int> listCharacterID = new List<int>();
    public List<int> ListMap = new List<int>();
}