using System;

[System.Serializable]
public class GameData
{
    public int recordID;
    public int disaster_id;
    public string time;
    public string ID;
}

[System.Serializable]
public class GameDataList
{
    public GameData[] items;
}
