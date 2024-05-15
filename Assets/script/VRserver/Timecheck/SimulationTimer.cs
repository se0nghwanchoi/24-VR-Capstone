using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// ������

public class SimulationTimer : MonoBehaviour
{
    private float SimStart;
    private bool Run;
    private string url = "http://localhost/Capstone24/TimeCheck.php";
    //private string url = "http://211.250.192.52:8080/Capstone24/TimeCheck.php";
    public void Start()
    {
        StartSimulation();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) // ���� ���, ����1 Ű�� ������ ����
        {
            EndSimulation();
        }

    }
    // �ùķ��̼� ���� �� ȣ��
    public void StartSimulation()
    {
        Debug.Log("���۽ð�" + Time.time);
        if (!Run)
        {
            SimStart = Time.time;
            Run = true;
        }
    }

    // �ùķ��̼� ���� �� ȣ��
    public void EndSimulation()
    {
        Debug.Log("����ð�" + Time.time);
        if (Run)
        {
            float Sim_end = Time.time;
            float Sim_clear = Sim_end - SimStart;
            Run = false;

            // clearTimeInSeconds�� ������ ����
            SendClearTimeToServer(Sim_clear);
        }
    }

    private void SendClearTimeToServer(float Sim_clear)
    {
        // clearTimeInSeconds ���� ������ �����ϴ� �ڵ�
        // ���⼭�� PostClearTime �ڷ�ƾ�� ����� ���Դϴ�.
        StartCoroutine(PostClearTime(Sim_clear));
    }


    private IEnumerator PostClearTime(float Sim_clear)
    {
        int recordID = PlayerPrefs.GetInt("RecordID");
        string formattedTime = FormatTime(Sim_clear);
        WWWForm form = new WWWForm();
        form.AddField("recordID", recordID);
        form.AddField("time", formattedTime);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error while sending clear time: " + www.error);
            }
            else
            {
                Debug.Log("Clear time sent successfully: " + Sim_clear);
            }
        }
    }
    private string FormatTime(float timeInSeconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        return timeSpan.ToString("hh\\:mm\\:ss");
    }
}