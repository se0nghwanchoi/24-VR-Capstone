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
        // 모든 화면 초기화
        ResetAllScreens();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        // 이벤트 리스너 등록
        selectEntered.AddListener(OnPickUp);
        selectExited.AddListener(OnPutDown);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        // 이벤트 리스너 제거
        selectEntered.RemoveListener(OnPickUp);
        selectExited.RemoveListener(OnPutDown);
    }

    // 핸드폰을 집었을 때 실행되는 메서드
    private void OnPickUp(SelectEnterEventArgs arg)
    {
        Debug.Log("Phone picked up");
        audioSource.PlayOneShot(pickUpSound);
        initialScreen.SetActive(false);
        callScreen.SetActive(true);
        Invoke("ChangeToReportComplete", pickUpSound.length);
    }

    // 전화 걸기가 끝난 후 호출되는 메서드
    private void ChangeToReportComplete()
    {
        audioSource.PlayOneShot(callEndSound);
        callScreen.SetActive(false);
        reportCompleteScreen.SetActive(true);
    }

    // 핸드폰을 내려놓았을 때 실행되는 메서드
    private void OnPutDown(SelectExitEventArgs arg)
    {
        Debug.Log("Phone put down");
        ResetAllScreens();
    }

    // 폰 상태를 초기 상태로 리셋
    private void ResetAllScreens()
    {
        initialScreen.SetActive(true);
        callScreen.SetActive(false);
        reportCompleteScreen.SetActive(false);
    }
}