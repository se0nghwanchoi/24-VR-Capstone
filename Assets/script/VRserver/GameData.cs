using System;

[System.Serializable]
public class GameData
{
    public int recordID;
    public int disaster_id;
    public string play_time;
    public string User_id;
}

[System.Serializable]
public class GameDataList
{
    public GameData[] items;
}
