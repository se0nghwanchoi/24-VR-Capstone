using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventController : MonoBehaviour
{
    public AudioSource audioSource; // �ȳ� ��ۿ� AudioSource
    public AudioClip arrivalClip; // ����� ����� Ŭ��
    public GameObject arrow; // ȭ��ǥ GameObject
    private bool hasTriggered = false; // �̺�Ʈ�� �̹� �߻��ߴ��� �����ϴ� ����

    private void Start()
    {
        arrow.SetActive(false); // ���� �� ȭ��ǥ ��Ȱ��ȭ
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        // �÷��̾� �±׸� ���� ������Ʈ�� Ʈ���ſ� �����ϰ�, �̺�Ʈ�� ���� �߻����� �ʾҴٸ�
        if (other.CompareTag("Player") && !hasTriggered)
        {
            StartCoroutine(PlayAudioAndShowArrow());
            hasTriggered = true; // �̺�Ʈ �߻� ǥ��
        }
    }

    IEnumerator PlayAudioAndShowArrow()
    {


        Debug.Log("����� ���"); // ����� ��� �α�
        audioSource.PlayOneShot(arrivalClip); // �ȳ� ��� ���
        yield return new WaitForSeconds(arrivalClip.length); // ����� Ŭ�� ���̸�ŭ ���
        Debug.Log("ȭ��ǥ Ȱ��ȭ"); // ȭ��ǥ Ȱ��ȭ �α�
        arrow.SetActive(true); // ȭ��ǥ Ȱ��ȭ
        yield return new WaitForSeconds(20); // 20�� ���� ���
        arrow.SetActive(false); // ȭ��ǥ ��Ȱ��ȭ
    }
}
