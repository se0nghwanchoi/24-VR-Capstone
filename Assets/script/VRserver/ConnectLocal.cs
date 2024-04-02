using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectLocal : MonoBehaviour
{
    private string url = "http://localhost/Capstone24/test.php";

    // ������ ������ �� ȣ��˴ϴ�.
    void Start()
    {
        StartCoroutine(GetDataFromDatabase());
    }

    // �����ͺ��̽����� �����͸� �������� �ڷ�ƾ
    IEnumerator GetDataFromDatabase()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("������ �����ϴ� �� �����߽��ϴ�: " + www.error);
        }
        else
        {
            // ���� ���� ���
            Debug.Log("���� ����: " + www.downloadHandler.text);
        }
    }
}
