using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisasterSelect : MonoBehaviour
{
    // PHP 스크립트 URL
    private string fireurl = "http://localhost/Capstone24/fireSelection.php";
    private string earthquakeurl = "http://localhost/Capstone24/earthquakeSelection.php";
    private string typhoonurl = "http://localhost/Capstone24/typhoonSelection.php";
    // 버튼에 연결할 메소드
    public void OnDisasterSelected(string disasterName)
    {
        StartCoroutine(SendDisasterSelectionToServer(disasterName));
    }

    // 서버로 사용자 선택을 보내는 코루틴
    IEnumerator SendDisasterSelectionToServer(string disaster)
    {
        if (disaster == "fire") {
            WWWForm form = new WWWForm();
            form.AddField("disaster", disaster);

            using (UnityWebRequest www = UnityWebRequest.Post(fireurl, form))
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

        else if (disaster == "earthquake")
        {
            WWWForm form = new WWWForm();
            form.AddField("disaster", disaster);

            using (UnityWebRequest www = UnityWebRequest.Post(earthquakeurl, form))
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

        else if (disaster == "typhoon")
        {
            WWWForm form = new WWWForm();
            form.AddField("disaster", disaster);

            using (UnityWebRequest www = UnityWebRequest.Post(typhoonurl, form))
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
}
