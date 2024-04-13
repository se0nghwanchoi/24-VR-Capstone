using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.XR.Interaction.Toolkit;

public class FireExtinguisherAct : MonoBehaviour
{
    private InteractionTimer interactionTimer;
    private XRGrabInteractable grabInteractable;
    private float totalInteractionTime = 0;
    private bool Used = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // 예를 들어, Esc 키를 누르면 종료
        {
            StartCoroutine(TowelInteracts(totalInteractionTime, Used));
        }
    }
    private void Awake()
    {
        interactionTimer = GetComponent<InteractionTimer>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (interactionTimer == null || grabInteractable == null)
        {
            Debug.LogError("필수 컴포넌트가 누락되었습니다!");
            return;
        }

        grabInteractable.selectEntered.AddListener(StartInteraction);
        grabInteractable.selectExited.AddListener(EndInteraction);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(StartInteraction);
        grabInteractable.selectExited.RemoveListener(EndInteraction);
    }

    private void StartInteraction(SelectEnterEventArgs args)
    {
        Debug.Log("상호작용 시작");
        interactionTimer.StartInteraction();
        Used = true;
    }

    private void EndInteraction(SelectExitEventArgs args)
    {
        interactionTimer.EndInteraction();
        totalInteractionTime = interactionTimer.GetTotalInteractionTime();
        Debug.Log($"Total Interaction Time with FireExtinguisher: {totalInteractionTime}");
        //StartCoroutine(TowelInteracts(totalInteractionTime));
    }

    private IEnumerator TowelInteracts(float interactionTime, bool usedStatus)
    {
        int recordID = PlayerPrefs.GetInt("RecordID");
        WWWForm form = new WWWForm();
        form.AddField("recordID", recordID);
        form.AddField("doCode", 3);
        form.AddField("interactionTime", interactionTime.ToString());
        form.AddField("useStatus", usedStatus ? "1" : "0");

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
