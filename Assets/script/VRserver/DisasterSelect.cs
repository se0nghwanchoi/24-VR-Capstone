using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisasterSelect : MonoBehaviour
{
    // PHP ��ũ��Ʈ URL
    private string fireurl = "http://localhost/Capstone24/fireSelection.php";
    private string earthquakeurl = "http://localhost/Capstone24/earthquakeSelection.php";
    private string typhoonurl = "http://localhost/Capstone24/typhoonSelection.php";
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
        form.AddField("disaaster", disaster);
        form.AddField("ID", studentID);

        string url = "";
        switch (disaster) { 
            case "fire":
                url = fireurl;
                break;
            case "earthquake":
                url = earthquakeurl;
                break;
            case "typhoon":
                url = typhoonurl;
                break;
        }
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                Debug.Log("Disaster and ID record: " + disaster + "," + studentID);
            }
        }
    }
    
}
