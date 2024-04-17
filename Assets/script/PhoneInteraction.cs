using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneArrowAndSound : MonoBehaviour
{
    public XRGrabInteractable grabInteractable; // 참조할 XRGrabInteractable
    public AudioSource audioSource; // 폰 객체에 추가된 AudioSource 컴포넌트
    public AudioSource audioSource2; // 핸드폰 벨소리를 재생할 두 번째 AudioSource 컴포넌트
    public AudioClip pickupSound; // 재생하고 싶은 오디오 클립 (효과음)
    public AudioClip ringtoneSound; // 핸드폰 벨소리 오디오 클립
    public GameObject arrow; // 이게 핸드폰 집고 다음에 생기는 에로우 
    public GameObject ArrowPosition; // 두 번째 화살표 GameObject 를 비활성화 하기 위한 코드 (핸드폰 위치 알려주는 화살표)


    void Start()
    {
        audioSource2.volume = 1.5f; // 핸드폰 벨소리 볼륨을 150%로 설정
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(HandleSelectEntered);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(HandleSelectEntered);
    }

    private void HandleSelectEntered(SelectEnterEventArgs arg)
    {
        audioSource.PlayOneShot(pickupSound); // 효과음 클립 재생
        audioSource2.PlayOneShot(ringtoneSound); // 벨소리 클립 재생
        StartCoroutine(ActivateArrowAfterSound(pickupSound.length)); // 오디오 클립 재생 후 화살표 활성화
    }

    private IEnumerator ActivateArrowAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        arrow.SetActive(true); // 오디오 클립 재생이 끝나고 화살표 활성화
        StartCoroutine(HideArrowAfterTime(15)); // 15초 후 첫 번째 화살표 비활성화
    }

    private IEnumerator HideArrowAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        arrow.SetActive(false); // 첫 번째 화살표 비활성화
    }

    private IEnumerator HideSecondArrowAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ArrowPosition.SetActive(false); // 두 번째 화살표 비활성화
    }
}