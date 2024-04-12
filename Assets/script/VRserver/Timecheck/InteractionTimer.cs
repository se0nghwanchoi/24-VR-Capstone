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
            Debug.Log("Interaction started at: " + startTime);
        }
    }

    // ��ȣ�ۿ� ����
    public void EndInteraction()
    {
        if (Interac)
        {
            Interac = false;
            float endTime = Time.time;
            float allinterac = endTime - startTime;
            Interac_alltime += allinterac;
            Debug.Log("Interaction ended at: " + endTime + ". Duration: " + allinterac);
        }
    }

    // ��ȣ�ۿ� �ð��� ��ȯ
    public float GetTotalInteractionTime()
    {
        return Interac_alltime;
    }
}