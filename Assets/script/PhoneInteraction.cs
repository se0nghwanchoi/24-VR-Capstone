using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneArrowAndSound : MonoBehaviour
{
    public XRGrabInteractable grabInteractable; // ������ XRGrabInteractable
    public AudioSource audioSource; // �� ��ü�� �߰��� AudioSource ������Ʈ
    public AudioClip pickupSound; // ����ϰ� ���� ����� Ŭ��
    public GameObject arrow; // ȭ��ǥ GameObject

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
        audioSource.PlayOneShot(pickupSound); // ����� Ŭ�� ���
        arrow.SetActive(true); // ȭ��ǥ Ȱ��ȭ
        StartCoroutine(HideArrowAfterTime(5)); // 5�� �� ȭ��ǥ ��Ȱ��ȭ
    }

    private IEnumerator HideArrowAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        arrow.SetActive(false); // ȭ��ǥ ��Ȱ��ȭ
    }
}