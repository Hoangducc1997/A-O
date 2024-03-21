using UnityEngine;

[CreateAssetMenu]
public class MapsDatabase : ScriptableObject
{
    public Maps[] maps;

    public int MapsCount
    {
        get
        {
            return maps.Length;
        }
    }

    public Maps GetMaps(int index)
    {
        return maps[index];
    }
}
