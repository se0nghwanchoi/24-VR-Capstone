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

        if (Input.GetKeyDown(KeyCode.Alpha1)) // 예를 들어, 숫자1 키를 누르면 종료
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
                DisplayData(records);
            }
        }
    }

    void DisplayData(GameData[] records)
    {

        foreach (GameData record in records)
        {
            string baseinfo = $"학번: {record.ID}                 총 플레이 시간: {record.time}\n";
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
                    doCodeInfo = $"아이템: 수건              상호작용 시간: {doCode.interact_time}\n";

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
                        doCodeInfo = $"아이템: 핸드폰          핸드폰 신고: O\n";
                        count += 2;
                    }
                    else
                        doCodeInfo = $"아이템: 핸드폰          핸드폰 신고: X\n";
                }

                else if (doCode.Do_code == 3)
                {
                    doCodeInfo = $"아이템: 소화기          상호작용 시간: {doCode.interact_time}\n";

                    TimeSpan firetimeSpan = TimeSpan.Parse(doCode.interact_time);
                    int fireSecond = (int)firetimeSpan.TotalSeconds;

                    if (fireSecond <= 15 && fireSecond > 0)
                        count++;
                }

                else if (doCode.Do_code == 4)
                {
                    if (doCode.use_status == 1)
                    {
                        doCodeInfo = $"아이템: 비상벨          비상벨 작동 여부: O\n";
                        count++;
                    }
                    else
                        doCodeInfo = $"아이템: 비상벨          비상벨 작동 여부: X\n";
                }
                else if (doCode.Do_code == 5)
                {
                    if(doCode.use_status == 1)
                    {
                        doCodeInfo = $"아이템: 화재밸브       화재밸브 작동 여부: O\n";
                        count++;
                    }
                    else
                        doCodeInfo = $"아이템: 화재밸브       화재밸브 작동 여부: X\n";
                }
                //string doCodeInfo = $"Do_code: {doCode.Do_code}, Interact_time: {doCode.interact_time}, Use Status: {doCode.use_status}\n";
                RecordText.text += doCodeInfo;

            }
            RecordText.text += $"유독가스 노출 시간: {toxicGas}초\n";

            RecordText.text += "\n\n";
            if (count == 6)
                RecordText.text += "                       위기 상황 대응능력: A ";
            else if (count == 5)
                RecordText.text += "                       위기 상황 대응능력: B ";
            else if (count == 4)
                RecordText.text += "                       위기 상황 대응능력: C ";
            else if (count == 3)
                RecordText.text += "                       위기 상황 대응능력: D ";
            else
                RecordText.text += "                       위기 상황 대응능력: E ";
        }
    }
}
