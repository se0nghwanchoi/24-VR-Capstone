using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneArrowAndSound : MonoBehaviour
{
    public XRGrabInteractable grabInteractable; // ������ XRGrabInteractable
    public AudioSource audioSource; // �� ��ü�� �߰��� AudioSource ������Ʈ
    public AudioSource audioSource2; // �ڵ��� ���Ҹ��� ����� �� ��° AudioSource ������Ʈ
    public AudioClip pickupSound; // ����ϰ� ���� ����� Ŭ�� (ȿ����)
    public AudioClip ringtoneSound; // �ڵ��� ���Ҹ� ����� Ŭ��
    public GameObject arrow; // �̰� �ڵ��� ���� ������ ����� ���ο� 
    public GameObject ArrowPosition; // �� ��° ȭ��ǥ GameObject �� ��Ȱ��ȭ �ϱ� ���� �ڵ� (�ڵ��� ��ġ �˷��ִ� ȭ��ǥ)


    void Start()
    {
        audioSource2.volume = 1.5f; // �ڵ��� ���Ҹ� ������ 150%�� ����
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
        audioSource.PlayOneShot(pickupSound); // ȿ���� Ŭ�� ���
        audioSource2.PlayOneShot(ringtoneSound); // ���Ҹ� Ŭ�� ���
        StartCoroutine(ActivateArrowAfterSound(pickupSound.length)); // ����� Ŭ�� ��� �� ȭ��ǥ Ȱ��ȭ
    }

    private IEnumerator ActivateArrowAfterSound(float delay)
    {
        yield return new WaitForSeconds(delay);
        arrow.SetActive(true); // ����� Ŭ�� ����� ������ ȭ��ǥ Ȱ��ȭ
        StartCoroutine(HideArrowAfterTime(15)); // 15�� �� ù ��° ȭ��ǥ ��Ȱ��ȭ
    }

    private IEnumerator HideArrowAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        arrow.SetActive(false); // ù ��° ȭ��ǥ ��Ȱ��ȭ
    }

    private IEnumerator HideSecondArrowAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ArrowPosition.SetActive(false); // �� ��° ȭ��ǥ ��Ȱ��ȭ
    }
}