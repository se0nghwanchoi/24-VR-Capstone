using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTimer : MonoBehaviour
{
    private float startTime;
    private float Interac_alltime;
    private bool Interac;

    void Update()
    {
        // 상호작용 중이라면 각 프레임마다 시간을 업데이트
        if (Interac)
        {
            Interac_alltime += Time.deltaTime;
        }
    }

    // 상호작용 시작
    public void StartInteraction()
    {
        if (!Interac)
        {
            startTime = Time.time;
            Interac = true;
        }
    }

    // 상호작용 종료
    public void EndInteraction()
    {
        if (Interac)
        {
            Interac = false;
            float endTime = Time.time;
            float interactionDuration = endTime - startTime;
            Interac_alltime += interactionDuration;
            Debug.Log("Interaction ended. Total interaction time: " + Interac_alltime + " seconds.");
        }
    }

    // 상호작용 시간을 반환
    public float GetTotalInteractionTime()
    {
        return Interac_alltime;
    }
}