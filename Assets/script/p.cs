
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class p : XRGrabInteractable
{
    public AudioSource audioSource;
    public AudioClip ringSound; // ��ȭ �ɱ� �Ҹ�
    public AudioClip reportCompleteSound; // �Ű� �Ϸ� �Ҹ�

    public GameObject screen1; // �ʱ� ���ȭ��
    public GameObject screen2; // ��ȭ �Ŵ� ȭ��
    public GameObject screen3; // �Ű� �Ϸ� ȭ��
    public Transform leftHandAttachPoint;
    public Transform rightHandAttachPoint;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        // Grabbed by left hand
        if (interactor is XRDirectInteractor directInteractor && directInteractor.selectTarget == this && directInteractor.CompareTag("LeftHand"))
        {
            if (leftHandAttachPoint != null)
                attachTransform = leftHandAttachPoint;
        }
        // Grabbed by right hand
        else if (interactor is XRDirectInteractor directInteractor2 && directInteractor2.selectTarget == this && directInteractor2.CompareTag("RightHand"))
        {
            if (rightHandAttachPoint != null)
                attachTransform = rightHandAttachPoint;
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        StartCall();
    }

    void StartCall()
    {
        // ȭ�� ��ȯ
        screen1.SetActive(false);
        screen2.SetActive(true);

        // ��ȭ �ɱ� �Ҹ� ���
        audioSource.clip = ringSound;
        audioSource.Play();
        Invoke("SwitchToReportComplete", ringSound.length);
    }

    void SwitchToReportComplete()
    {
        // �Ű� �Ϸ� ȭ������ ��ȯ
        screen2.SetActive(false);
        screen3.SetActive(true);

        // �Ű� �Ϸ� �Ҹ� ���
        audioSource.clip = reportCompleteSound;
        audioSource.Play();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        ResetPhone();
    }

    void ResetPhone()
    {
        // ��� ȭ���� �ʱ� ���·� ����
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);

        // ����� ����
        audioSource.Stop();
    }
}