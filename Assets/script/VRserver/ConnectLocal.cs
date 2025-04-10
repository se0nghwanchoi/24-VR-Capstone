using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectLocal : MonoBehaviour
{
    private string url = "http://localhost/Capstone24/recordSelection.php";
    //private string url = "http://211.250.192.52:8080/Capstone24/recordSelection.php";
    // 게임이 시작할 때 호출됩니다.
    void Start()
    {
        StartCoroutine(PostRequest(url));
    }

    // 데이터베이스에서 데이터를 가져오는 코루틴
    IEnumerator PostRequest(string url)
    {
        string studentID = "1971383";
        string disaster = "fire";
        WWWForm form = new WWWForm();
        form.AddField("ID", studentID);
        form.AddField("disaster", disaster);
        using(UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Data send success: " + www.downloadHandler.text);
            }
        }
    }
}
