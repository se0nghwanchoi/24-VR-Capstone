using System.Collections;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; // If you want to display the results on UI elements

public class GameDataLoader : MonoBehaviour
{
    public string apiUrl = "http://localhost/Capstone24/ApiLoad.php";
    public Text RecordText;

    // Start is called before the first frame update
    void Start()
    {
        int recordID = PlayerPrefs.GetInt("RecordID");
        StartCoroutine(GetGameData(recordID));
    }

    IEnumerator GetGameData(int recordID)
    {
        string url = apiUrl + "?recordID=" + recordID.ToString();
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;
                Debug.Log("Received JSON: " + jsonResponse);

                // JSON �����͸� �Ľ��Ͽ� �� ���ڵ��� ������ ����� �α׿� ���
                GameData[] records = JsonUtility.FromJson<GameDataList>(jsonResponse).items;
                foreach (GameData record in records)
                {
                    Debug.Log($"Record ID: {record.recordID}, User ID: {record.User_id}, Disaster ID: {record.disaster_id}, Time: {record.play_time}");
                }
            }
        }
    }
}
