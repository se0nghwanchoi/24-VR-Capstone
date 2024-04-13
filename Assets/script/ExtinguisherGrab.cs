
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtinguisherGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        // XRGrabInteractable 컴포넌트를 가져옵니다.
        grabInteractable = GetComponent<XRGrabInteractable>();

        // 그랩 상태 변경 이벤트에 대한 리스너를 추가합니다.
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // 그랩된 상태일 때, Rigidbody를 Kinematic으로 변경하여 물리 업데이트를 중지합니다.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            
            rb.isKinematic = true;
        }
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // 그랩 해제 상태일 때, Rigidbody를 다시 Kinematic에서 NonKinematic으로 변경하여 물리 업데이트를 재개합니다.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
           
            rb.isKinematic = false;
        }
    }
}
