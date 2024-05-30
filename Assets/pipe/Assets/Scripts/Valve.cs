using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mouledoux.Components;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Valve : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // 참조할 XRInteractable
    public string valveTag;

    [SerializeField, Range(0f, 1f)]
    private float _flowRate = 1f;
    public float flowRate
    {
        get { return _flowRate; }
        set { _flowRate = Mathf.Clamp01(value); }
    }

    public AnimationStepper animScrubber;

    Mouledoux.Callback.Packet subPacket = new Mouledoux.Callback.Packet();

    public float adjustmentSpeed = 0.1f; // Flow rate adjustment speed

    public void Awake()
    {
        if (animScrubber != null) animScrubber.initStartPoint = flowRate;
    }

    private void Start()
    {
        NotifySubs();
    }

    void OnEnable()
    {
        simpleInteractable.selectEntered.AddListener(HandleSelectEntered);
        simpleInteractable.selectExited.AddListener(HandleSelectExited);
    }

    void OnDisable()
    {
        simpleInteractable.selectEntered.RemoveListener(HandleSelectEntered);
        simpleInteractable.selectExited.RemoveListener(HandleSelectExited);
    }

    public void HandleSelectEntered(SelectEnterEventArgs arg)
    {
        // 수정된 부분 시작: interactorObject에서 XRController를 가져옴
        if (arg.interactorObject is XRBaseControllerInteractor controllerInteractor && controllerInteractor.xrController is XRController controller)
        {
            StartCoroutine(AdjustFlowRateCoroutine(controller));
        }
        // 수정된 부분 끝
    }

    public void HandleSelectExited(SelectExitEventArgs arg)
    {
        StopAllCoroutines();
    }

    private IEnumerator AdjustFlowRateCoroutine(XRController controller)
    {
        while (true)
        {
            if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 input))
            {
                if (input.y != 0)
                {
                    AdjustFlowRate(input.y * adjustmentSpeed);
                }
            }
            yield return null;
        }
    }

    public void AdjustFlowRate(float adjustmentRate)
    {
        flowRate += adjustmentRate * Time.deltaTime;
        NotifySubs();
        if (animScrubber != null) animScrubber.SetAnimationPosition(flowRate);
    }

    private void NotifySubs()
    {
        subPacket.floats = new float[] { flowRate };
        Mediator.instance.NotifySubscribers(valveTag.ToLower() + "->setflow", subPacket);
    }
}
