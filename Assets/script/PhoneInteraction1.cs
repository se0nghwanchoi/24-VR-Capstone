using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneInteraction : XRGrabInteractable
{
    public GameObject initialScreen;
    public GameObject callScreen;
    public GameObject reportCompleteScreen;

    public AudioSource audioSource;
    public AudioClip pickUpSound;
    public AudioClip callEndSound;

    protected override void Awake()
    {
        base.Awake();
        // ��� ȭ�� �ʱ�ȭ
        ResetAllScreens();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        // �̺�Ʈ ������ ���
        selectEntered.AddListener(OnPickUp);
        selectExited.AddListener(OnPutDown);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        // �̺�Ʈ ������ ����
        selectEntered.RemoveListener(OnPickUp);
        selectExited.RemoveListener(OnPutDown);
    }

    // �ڵ����� ������ �� ����Ǵ� �޼���
    private void OnPickUp(SelectEnterEventArgs arg)
    {
        Debug.Log("Phone picked up");
        audioSource.PlayOneShot(pickUpSound);
        initialScreen.SetActive(false);
        callScreen.SetActive(true);
        Invoke("ChangeToReportComplete", pickUpSound.length);
    }

    // ��ȭ �ɱⰡ ���� �� ȣ��Ǵ� �޼���
    private void ChangeToReportComplete()
    {
        audioSource.PlayOneShot(callEndSound);
        callScreen.SetActive(false);
        reportCompleteScreen.SetActive(true);
    }

    // �ڵ����� ���������� �� ����Ǵ� �޼���
    private void OnPutDown(SelectExitEventArgs arg)
    {
        Debug.Log("Phone put down");
        ResetAllScreens();
    }

    // �� ���¸� �ʱ� ���·� ����
    private void ResetAllScreens()
    {
        initialScreen.SetActive(true);
        callScreen.SetActive(false);
        reportCompleteScreen.SetActive(false);
    }
}