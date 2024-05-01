using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisasterSelect : MonoBehaviour
{
    // PHP ��ũ��Ʈ URL
    private string url = "http://localhost/Capstone24/disasterSelection.php";

    // ��ư�� ������ �޼ҵ�
    public void OnDisasterSelected(string disasterName)
    {
        StartCoroutine(SendDisasterSelectionToServer(disasterName));
    }

    // ������ ����� ������ ������ �ڷ�ƾ
    IEnumerator SendDisasterSelectionToServer(string disaster)
    {
        string studentID = IDmanager.Instance.StudentID;

        WWWForm form = new WWWForm();
        form.AddField("disaster", disaster); //"fire"); //disaster); ������ fire�� �־���
        form.AddField("ID", studentID); //"123"); //studentID); // id �Է� �ȹ����� ������ 123���� �־���

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

                // PlayerPrefs�� ����Ͽ� recordID, Student ID ����
                PlayerPrefs.SetInt("RecordID", recordID);
                PlayerPrefs.SetString("studentID", studentID); //"123"); // studentID); id�Է� �ȹ����� ������ 123���� �־���
                PlayerPrefs.Save();
            }
        }
    }
    
}
