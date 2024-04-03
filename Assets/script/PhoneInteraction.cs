using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneArrowAndSound : MonoBehaviour
{
    public XRGrabInteractable grabInteractable; // 참조할 XRGrabInteractable
    public AudioSource audioSource; // 폰 객체에 추가된 AudioSource 컴포넌트
    public AudioClip pickupSound; // 재생하고 싶은 오디오 클립
    public GameObject arrow; // 첫 번째 화살표 GameObject
    public GameObject secondArrow; // 두 번째 화살표 GameObject

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
        audioSource.PlayOneShot(pickupSound); // 오디오 클립 재생
        arrow.SetActive(true); // 첫 번째 화살표 활성화
        StartCoroutine(HideArrowAfterTime(5)); // 5초 후 첫 번째 화살표 비활성화
        StartCoroutine(HideSecondArrowAfterTime(25)); // 20초 후 두 번째 화살표 비활성화
    }

    private IEnumerator HideArrowAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        arrow.SetActive(false); // 첫 번째 화살표 비활성화
    }

    private IEnumerator HideSecondArrowAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        secondArrow.SetActive(false); // 두 번째 화살표 비활성화
    }
}