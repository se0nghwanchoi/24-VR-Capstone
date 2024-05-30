using System.Collections;
using System;
using System.Data;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI; // If you want to display the results on UI elements
using TMPro;

public class GameDataLoader : MonoBehaviour
{
    public string apiUrl = "http://localhost/Capstone24/ApiLoad.php";
    //public string apiUrl = "http://211.250.192.52:8080/Capstone24/ApiLoad.php";
    public TMP_Text RecordText;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� ���, ����1 Ű�� ������ ����
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
            string baseinfo = $"�й�: {record.ID}                 �� �÷��� �ð�: {record.time}\n";
            //string baseinfo = $"Record ID: {record.recordID}, User ID: {record.ID}, Disaster ID: {record.disaster_id}, Time: {record.time}\n";
            RecordText.text += baseinfo;

            TimeSpan totaltimeSpan = TimeSpan.Parse(record.time);
            int totalSeconds = (int)totaltimeSpan.TotalSeconds;
            int toxicGas = 0;

            if (totalSeconds > 180)
                count -= 10;

            foreach (var doCode in record.DoCodes)
            {
                string doCodeInfo = null;

                if (doCode.Do_code == 1)
                {
                    doCodeInfo = $"������: ����              ��ȣ�ۿ� �ð�: {doCode.interact_time}\n";

                    TimeSpan toweltimeSpan = TimeSpan.Parse(doCode.interact_time);
                    int towelSecond = (int)toweltimeSpan.TotalSeconds;

                    if (towelSecond >= (totalSeconds / 2))
                        count++;

                    toxicGas = totalSeconds - towelSecond;
                }

                else if (doCode.Do_code == 2)
                {
                    if (doCode.use_status == 1)
                    {
                        doCodeInfo = $"������: �ڵ���          �ڵ��� �Ű�: O\n";
                        count += 2;
                    }
                    else
                        doCodeInfo = $"������: �ڵ���          �ڵ��� �Ű�: X\n";
                }

                else if (doCode.Do_code == 3)
                {
                    doCodeInfo = $"������: ��ȭ��          ��ȣ�ۿ� �ð�: {doCode.interact_time}\n";

                    TimeSpan firetimeSpan = TimeSpan.Parse(doCode.interact_time);
                    int fireSecond = (int)firetimeSpan.TotalSeconds;

                    if (fireSecond <= 15 && fireSecond > 0)
                        count++;
                }

                else if (doCode.Do_code == 4)
                {
                    if (doCode.use_status == 1)
                    {
                        doCodeInfo = $"������: ���          ��� �۵� ����: O\n";
                        count++;
                    }
                    else
                        doCodeInfo = $"������: ���          ��� �۵� ����: X\n";
                }
                else if (doCode.Do_code == 5)
                {
                    if(doCode.use_status == 1)
                    {
                        doCodeInfo = $"������: ȭ����       ȭ���� �۵� ����: O\n";
                        count++;
                    }
                    else
                        doCodeInfo = $"������: ȭ����       ȭ���� �۵� ����: X\n";
                }
                //string doCodeInfo = $"Do_code: {doCode.Do_code}, Interact_time: {doCode.interact_time}, Use Status: {doCode.use_status}\n";
                RecordText.text += doCodeInfo;

            }
            RecordText.text += $"�������� ���� �ð�: {toxicGas}��\n";

            RecordText.text += "\n\n";
            if (count == 6)
                RecordText.text += "                       ���� ��Ȳ �����ɷ�: A ";
            else if (count == 5)
                RecordText.text += "                       ���� ��Ȳ �����ɷ�: B ";
            else if (count == 4)
                RecordText.text += "                       ���� ��Ȳ �����ɷ�: C ";
            else if (count == 3)
                RecordText.text += "                       ���� ��Ȳ �����ɷ�: D ";
            else
                RecordText.text += "                       ���� ��Ȳ �����ɷ�: E ";
        }
    }
}
