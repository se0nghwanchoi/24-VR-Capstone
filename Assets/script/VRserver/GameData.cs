[System.Serializable]
public class GameData
{
    public int recordID;
    public int Do_code;
    public int User_id;
    public int disaster_id;
    public string interact_time;
    public bool use_status;
    public string do_name;
    public string play_time;
}

[System.Serializable]
public class GameDataList
{
    public GameData[] items;
}