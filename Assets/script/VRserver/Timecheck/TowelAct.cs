using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowelAct : MonoBehaviour
{
    private InteractionTimer Interac_Time;

    private void Start()
    {
        Interac_Time = GetComponent<InteractionTimer>();
        if (Interac_Time == null)
        {
            Debug.LogError("InteractionTimer component is missing on this object!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 'Player'는 플레이어 오브젝트의 Tag입니다.
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
        }
    }
}
