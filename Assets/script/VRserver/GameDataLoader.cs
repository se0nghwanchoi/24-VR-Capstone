using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; // If you want to display the results on UI elements

public class GameDataLoader : MonoBehaviour
{
    public string apiUrl = "http://localhost/Capstone24/ApiLoad.php";
    int recordID = PlayerPrefs.GetInt("RecordID");
    string studentID = PlayerPrefs.GetString("studentID");

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
        // Parse the JSON data here and use it as needed
        Debug.Log("Received data: " + jsonData);

        // Example of how to use the JSON data:
        // You would need to define a class that matches the JSON structure and then use JsonUtility.FromJson<>
        // MyGameData myData = JsonUtility.FromJson<MyGameData>(jsonData);
        // Do something with the data
    }
}
