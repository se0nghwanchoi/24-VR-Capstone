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

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) // 예를 들어, Esc 키를 누르면 종료
        {

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        int recordID = PlayerPrefs.GetInt("RecordID");
        yield return new WaitForSeconds(0.2f);
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

                // JSON 데이터를 파싱하여 각 레코드의 내용을 디버그 로그에 출력
                GameData[] records = JsonUtility.FromJson<GameDataList>(jsonResponse).items;
                foreach (GameData record in records)
                {
                    Debug.Log($"Record ID: {record.recordID}, User ID: {record.ID}, Disaster ID: {record.disaster_id}, Time: {record.time}");

                    if (record.disaster_id == 1)
                    {
                        Debug.Log($"Do_code: {record.Do_code}, Interact time: {record.interact_time}, Use: {record.use_status}");
                    }
                }
            }
        }
    }
}
