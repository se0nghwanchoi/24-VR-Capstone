using System;

[System.Serializable]
public class GameData
{
    public int recordID;
    public int disaster_id;
    public string time;
    public string ID;
    public int Do_code;
    public string interact_time;
    public int use_status;
}

[System.Serializable]
public class GameDataList
{
    public GameData[] items;
}
