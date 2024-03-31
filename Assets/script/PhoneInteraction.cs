using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneArrowAndSound : MonoBehaviour
{
    public XRGrabInteractable grabInteractable; // 참조할 XRGrabInteractable
    public AudioSource audioSource; // 폰 객체에 추가된 AudioSource 컴포넌트
    public AudioClip pickupSound; // 재생하고 싶은 오디오 클립
    public GameObject arrow; // 화살표 GameObject

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
        arrow.SetActive(true); // 화살표 활성화
        StartCoroutine(HideArrowAfterTime(5)); // 5초 후 화살표 비활성화
    }

    private IEnumerator HideArrowAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        arrow.SetActive(false); // 화살표 비활성화
    }
}