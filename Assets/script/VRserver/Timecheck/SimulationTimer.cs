using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// ������

public class SimulationTimer : MonoBehaviour
{
    private float SimStart;
    private bool Run;

    public void Start()
    {
        StartSimulation();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) // ���� ���, Esc Ű�� ������ ����
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