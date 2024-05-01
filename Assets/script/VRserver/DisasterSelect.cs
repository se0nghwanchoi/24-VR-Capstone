using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisasterSelect : MonoBehaviour
{
    // PHP 스크립트 URL
    private string url = "http://localhost/Capstone24/disasterSelection.php";

    // 버튼에 연결할 메소드
    public void OnDisasterSelected(string disasterName)
    {
        StartCoroutine(SendDisasterSelectionToServer(disasterName));
    }

    // 서버로 사용자 선택을 보내는 코루틴
    IEnumerator SendDisasterSelectionToServer(string disaster)
    {
        string studentID = IDmanager.Instance.StudentID;

        WWWForm form = new WWWForm();
        form.AddField("disaster", disaster); //"fire"); //disaster); 강제로 fire로 넣어줌
        form.AddField("ID", studentID); //"123"); //studentID); // id 입력 안받으면 강제로 123으로 넣어줌

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                string jsonResponse = www.downloadHandler.text;
                var data = JsonUtility.FromJson<GameData>(jsonResponse);
                int recordID = data.recordID;

                // PlayerPrefs를 사용하여 recordID, Student ID 저장
                PlayerPrefs.SetInt("RecordID", recordID);
                PlayerPrefs.SetString("studentID", studentID); //"123"); // studentID); id입력 안받으면 강제로 123으로 넣어줌
                PlayerPrefs.Save();
            }
        }
    }
    
}
