using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionTimer : MonoBehaviour
{
    private float startTime;
    private float interacAllTime;
    private bool isInteracting;

    // 상호작용 시작
    public void StartInteraction()
    {
        if (!isInteracting)
        {
            startTime = Time.time;
            isInteracting = true;
            Debug.Log($"Interaction started at: {startTime}");
        }
    }

    // 상호작용 종료
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

    // 상호작용 시간을 반환
    public float GetTotalInteractionTime()
    {
        return interacAllTime;
    }
}