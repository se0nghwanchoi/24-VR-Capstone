using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// 수정용

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

        if (Input.GetKeyDown(KeyCode.Alpha1)) // 예를 들어, 숫자1 키를 누르면 종료
        {
            EndSimulation();
        }

    }
    // 시뮬레이션 시작 시 호출
    public void StartSimulation()
    {
        Debug.Log("시작시간" + Time.time);
        if (!Run)
        {
            SimStart = Time.time;
            Run = true;
        }
    }

    // 시뮬레이션 종료 시 호출
    public void EndSimulation()
    {
        Debug.Log("종료시간" + Time.time);
        if (Run)
        {
            float Sim_end = Time.time;
            float Sim_clear = Sim_end - SimStart;
            Run = false;

            // clearTimeInSeconds를 서버로 전송
            SendClearTimeToServer(Sim_clear);
        }
    }

    private void SendClearTimeToServer(float Sim_clear)
    {
        // clearTimeInSeconds 값을 서버로 전송하는 코드
        // 여기서는 PostClearTime 코루틴을 사용할 것입니다.
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