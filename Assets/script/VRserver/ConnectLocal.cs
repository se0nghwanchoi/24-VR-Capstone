using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectLocal : MonoBehaviour
{
    private string url = "http://localhost/Capstone24/test.php";

    // 게임이 시작할 때 호출됩니다.
    void Start()
    {
        StartCoroutine(GetDataFromDatabase());
    }

    // 데이터베이스에서 데이터를 가져오는 코루틴
    IEnumerator GetDataFromDatabase()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("서버에 연결하는 데 실패했습니다: " + www.error);
        }
        else
        {
            // 서버 응답 출력
            Debug.Log("서버 응답: " + www.downloadHandler.text);
        }
    }
}
