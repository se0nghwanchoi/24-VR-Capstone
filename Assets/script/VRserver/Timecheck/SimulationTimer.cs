using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SimulationTimer : MonoBehaviour
{
    private float SimStart;
    private bool Run;

    public void Start()
    {
        StartSimulation();
    }
    // 시뮬레이션 시작 시 호출
    public void StartSimulation()
    {
        if (!Run)
        {
            SimStart = Time.time;
            Run = true;
        }
    }

    // 시뮬레이션 종료 시 호출
    public void EndSimulation()
    {
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
        WWWForm form = new WWWForm();
        form.AddField("recordID", recordID);
        form.AddField("time", Sim_clear.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Capstone24/TimeCheck.php", form))
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
}

