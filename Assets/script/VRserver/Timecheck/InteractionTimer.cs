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
        // ��ȣ�ۿ� ���̶�� �� �����Ӹ��� �ð��� ������Ʈ
        if (Interac)
        {
            Interac_alltime += Time.deltaTime;
        }
    }

    // ��ȣ�ۿ� ����
    public void StartInteraction()
    {
        if (!Interac)
        {
            startTime = Time.time;
            Interac = true;
        }
    }

    // ��ȣ�ۿ� ����
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

    // ��ȣ�ۿ� �ð��� ��ȯ
    public float GetTotalInteractionTime()
    {
        return Interac_alltime;
    }
}