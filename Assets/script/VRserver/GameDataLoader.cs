using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; // If you want to display the results on UI elements

public class GameDataLoader : MonoBehaviour
{
    public string apiUrl = "http://localhost/Capstone24/ApiLoad.php";
    int recordID = PlayerPrefs.GetInt("RecordID");
    string studentID = PlayerPrefs.GetString("studentID");

    public Text studentIdText;
    public Text recordIdText;
    public Text disasterText;
    public Text playTimeText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetGameData(recordID));
    }

    IEnumerator GetGameData(int recordID)
    {
        string url = apiUrl + "?recordID=" + recordID;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                ProcessGameData(webRequest.downloadHandler.text);
            }
        }
    }

    void ProcessGameData(string jsonData)
    {
        GameDataList dataList = JsonUtility.FromJson<GameDataList>(jsonData);
        foreach (GameData data in dataList.items)
        {
            Debug.Log($"Record ID: {data.recordID}, Student ID: {data.User_id}, Disaster Name: {data.disaster_id}, Play Time: {data.play_time}");

            // UI 업데이트
            studentIdText.text = $"학번 : {data.User_id}";
            recordIdText.text = $"레코드 번호 : {data.recordID}";
            disasterText.text = $"선택한 재난 : {GetDisasterName(data.disaster_id)}";
            playTimeText.text = $"총 Play Time : {data.play_time}";
        }
    }

    // Disaster code to name helper
    string GetDisasterName(int code)
    {
        switch (code)
        {
            case 1: return "불";
            case 2: return "지진";
            default: return "알 수 없음";
        }
    }

}
