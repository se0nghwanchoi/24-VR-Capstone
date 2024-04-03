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
        // XRDirectInteractor üũ �� attachPoint ����
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
            // ȣ�� ������Ʈ�� ��Ʈ�ѷ��� ��ġ�� ȸ���� ���� ������Ʈ
            transform.position = attachPoint.position;
            transform.rotation = attachPoint.rotation;
        }
    }
}