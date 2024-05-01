using System;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int recordID;
    public int disaster_id;
    public string time;
    public string ID;
    public DoCode[] DoCodes;
}

[System.Serializable]
public class DoCode
{
    public int Do_code;
    public string interact_time;
    public int use_status;
}

[System.Serializable]
public class GameDataList
{
    public GameData[] items;
}
