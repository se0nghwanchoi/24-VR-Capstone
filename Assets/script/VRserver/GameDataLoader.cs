using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; // If you want to display the results on UI elements

public class GameDataLoader : MonoBehaviour
{
    public Text studentIdText;
    public Text recordIdText;
    public Text disasterText;
    public Text playTimeText;

    // Start is called before the first frame update
    void Start()
    {
        int recordID = PlayerPrefs.GetInt("RecordID");
        StartCoroutine(GetGameData(recordID));
    }

    IEnumerator GetGameData(int recordID)
    {
        string apiUrl = "http://localhost/Capstone24/ApiLoad.php";

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
        GameData data = JsonUtility.FromJson<GameData>(jsonData);
        Debug.Log(data.student_id);

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
