[System.Serializable]
public class GameData
{
    public int recordID;
    public int student_id;
    public int disaster_id;
    public string play_time;
}

[System.Serializable]
public class GameDataList
{
    public GameData[] items;
}