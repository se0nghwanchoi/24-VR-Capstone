using UnityEngine;

public class InteractionTimer : MonoBehaviour
{
    private float startTime;
    private float interacAllTime;
    private bool isInteracting;

    public void StartInteraction()
    {
        if (!isInteracting)
        {
            startTime = Time.time;
            isInteracting = true;
        }
    }

    public void EndInteraction()
    {
        if (isInteracting)
        {
            float endTime = Time.time;
            float interactionDuration = endTime - startTime;
            interacAllTime += interactionDuration;
            isInteracting = false;
            Debug.Log($"Total Interaction Time: {interacAllTime} seconds");
        }
    }

    public float GetTotalInteractionTime()
    {
        return interacAllTime;
    }
}