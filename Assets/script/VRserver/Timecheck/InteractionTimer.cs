using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionTimer : MonoBehaviour
{
    private float startTime;
    private float interacAllTime;
    private bool isInteracting;

    // ��ȣ�ۿ� ����
    public void StartInteraction()
    {
        if (!isInteracting)
        {
            startTime = Time.time;
            isInteracting = true;
            Debug.Log($"Interaction started at: {startTime}");
        }
    }

    // ��ȣ�ۿ� ����
    public void EndInteraction()
    {
        if (isInteracting)
        {
            isInteracting = false;
            float endTime = Time.time;
            float interactionDuration = endTime - startTime;
            interacAllTime += interactionDuration;
            Debug.Log($"Interaction ended at: {endTime}. Duration: {interactionDuration}");
        }
    }

    // ��ȣ�ۿ� �ð��� ��ȯ
    public float GetTotalInteractionTime()
    {
        return interacAllTime;
    }
}