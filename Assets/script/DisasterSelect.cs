using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DisasterSelect : MonoBehaviour
{
    private string url = "http://localhost/Capstone24/recordSelection.php";

    // 버튼에 연결할 메소드
    public void OnDisasterSelected(string disasterName)
    {
        StartCoroutine(SendDisasterSelectionToServer(disasterName));
    }

    // 서버로 사용자 선택을 보내는 코루틴
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
