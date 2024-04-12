using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.Interaction.Toolkit;

public class TowelAct : MonoBehaviour
{
    private InteractionTimer interactionTimer;

    private void Awake()
    {
        interactionTimer = GetComponent<InteractionTimer>();
        if (interactionTimer == null)
        {
            Debug.LogError("InteractionTimer component is missing on this object!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interaction with player started.");
            interactionTimer.StartInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionTimer.EndInteraction();
            float totalInteractionTime = interactionTimer.GetTotalInteractionTime();
            Debug.Log($"Total Interaction Time with Towel: {totalInteractionTime}");
            StartCoroutine(TowelInteracts(totalInteractionTime));
        }
    }

    private IEnumerator TowelInteracts(float interactionTime)
    {
        int recordID = PlayerPrefs.GetInt("RecordID");
        WWWForm form = new WWWForm();
        form.AddField("recordID", recordID);
        form.AddField("doCode", 1);
        form.AddField("interactionTime", interactionTime.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Capstone24/TowelActs.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error while sending interaction time: {www.error}");
            }
            else
            {
                Debug.Log("Interaction time sent successfully");
            }
        }
    }
}