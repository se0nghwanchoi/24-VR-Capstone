using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DisasterSelect : MonoBehaviour
{
    private string url = "http://localhost/Capstone24/recordSelection.php";

    // ��ư�� ������ �޼ҵ�
    public void OnDisasterSelected(string disasterName)
    {
        StartCoroutine(SendDisasterSelectionToServer(disasterName));
    }

    // ������ ����� ������ ������ �ڷ�ƾ
    IEnumerator SendDisasterSelectionToServer(string disaster)
    {
        WWWForm form = new WWWForm();
        form.AddField("disaster", disaster);
        string postURL = url + "?" + form;

        using (UnityWebRequest www = UnityWebRequest.Post(postURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                Debug.Log("Selection recorded: " + disaster);
            }
        }
    }
}
