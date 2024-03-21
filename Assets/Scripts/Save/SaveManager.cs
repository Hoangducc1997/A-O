using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    public static void Save(PlayerData data)
    {
        string path = Application.persistentDataPath + ".data.qnd";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }
    public static void Save()
    {
        Save(PlayerGameData.Instance.PlayerData);
    }

    public static PlayerData Load()
    {
        string path = GetPath();

        if (!File.Exists(path))
        {
            Debug.Log("No save data found. Creating new data.");
            PlayerData newPlayer = PlayerGameData.Instance.newPlayerData();
            Save(newPlayer);
            return newPlayer;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Open);
        PlayerData data = formatter.Deserialize(fs) as PlayerData;
        fs.Close();

        return data;
    }


    public static string GetPath()
    {
        return Application.persistentDataPath + ".data.qnd";
    }

    public static void DeleteSaveData()
    {
        string path = GetPath();
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save data deleted.");
        }
        else
        {
            Debug.Log("No save data found.");
        }
    }
}
