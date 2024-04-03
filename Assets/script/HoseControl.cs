using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoseControl : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Transform attachPoint;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(Grabbed);
        grabInteractable.selectExited.AddListener(Released);
    }

    private void Grabbed(SelectEnterEventArgs arg)
    {
        // XRDirectInteractor 체크 및 attachPoint 설정
        if (arg.interactor is XRDirectInteractor)
        {
            attachPoint = ((XRDirectInteractor)arg.interactor).attachTransform;
        }
    }

    private void Released(SelectExitEventArgs arg)
    {
        attachPoint = null;
    }

    void Update()
    {
        if (attachPoint != null)
        {
            // 호스 오브젝트를 컨트롤러의 위치와 회전에 맞춰 업데이트
            transform.position = attachPoint.position;
            transform.rotation = attachPoint.rotation;
        }
    }
}