using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TowelAct : MonoBehaviour
{
    private InteractionTimer Interac_Time;

    private void Start()
    {
        Interac_Time = GetComponent<InteractionTimer>();
        if (Interac_Time == null)
        {
            Debug.LogError("��ȣ�ۿ� ���� ! ");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 'Player'�� �÷��̾� ������Ʈ�� Tag�Դϴ�.
        {
            Interac_Time.StartInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interac_Time.EndInteraction();
            float totalInteractionTime = Interac_Time.GetTotalInteractionTime();
            Debug.Log("Total Interaction Time with Handkerchief: " + totalInteractionTime);
            StartCoroutine(Towelinteracts(totalInteractionTime));
        }
    }
    private IEnumerator Towelinteracts(float interactionTime)
    {
        int recordID = PlayerPrefs.GetInt("RecordID"); // PlayerPrefs���� recordID�� ������
        WWWForm form = new WWWForm();
        form.AddField("recordID", recordID);
        form.AddField("doCode", 1);
        form.AddField("interactionTime", interactionTime.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Capstone24/TowelActs.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error while sending interaction time: " + www.error);
            }
            else
            {
                Debug.Log("Interaction time sent successfully");
            }
        }
    }
}
