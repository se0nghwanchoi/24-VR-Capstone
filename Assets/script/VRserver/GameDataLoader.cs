using System.Collections;
using System.Data;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; // If you want to display the results on UI elements
using TMPro;

public class GameDataLoader : MonoBehaviour
{
    public string apiUrl = "http://localhost/Capstone24/ApiLoad.php";
    public TMP_Text RecordText;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) // ���� ���, Esc Ű�� ������ ����
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

                // JSON �����͸� �Ľ��Ͽ� �� ���ڵ��� ������ ����� �α׿� ���
                GameData[] records = JsonUtility.FromJson<GameDataList>(jsonResponse).items;
                DisplayData(records);
            }
        }
    }
    void DisplayData(GameData[] records)
    {
        foreach (GameData record in records)
        {
            // �����͸� ���ڿ� ���·� ��ȯ�Ͽ� UI Text�� ǥ��
            string displayText = $"Record ID: {record.recordID}, User ID: {record.ID}, Disaster ID: {record.disaster_id}, Time: {record.time}";
            RecordText.text += displayText + "\n";  // UI Text�� ������ �߰�
        }
    }
}
