
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class p : XRGrabInteractable
{
    public AudioSource audioSource;
    public AudioClip ringSound; // 전화 걸기 소리
    public AudioClip reportCompleteSound; // 신고 완료 소리

    public GameObject screen1; // 초기 배경화면
    public GameObject screen2; // 전화 거는 화면
    public GameObject screen3; // 신고 완료 화면

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        StartCall();
    }

    void StartCall()
    {
        // 화면 전환
        screen1.SetActive(false);
        screen2.SetActive(true);

        // 전화 걸기 소리 재생
        audioSource.clip = ringSound;
        audioSource.Play();
        Invoke("SwitchToReportComplete", ringSound.length);
    }

    void SwitchToReportComplete()
    {
        // 신고 완료 화면으로 전환
        screen2.SetActive(false);
        screen3.SetActive(true);

        // 신고 완료 소리 재생
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
        // 모든 화면을 초기 상태로 복원
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);

        // 오디오 정지
        audioSource.Stop();
    }
}