using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrill : MonoBehaviour
{
    public GameObject arrow; // ȭ��ǥ ��ü
    public AudioClip broadcast; // �ȳ� ��� ����� Ŭ��
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        arrow.SetActive(false); // �ʱ⿡�� ȭ��ǥ�� ����ϴ�.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 'Player' �±׸� ���� ��ü�� �ݸ����� ���� ���
        {
            audioSource.clip = broadcast;
            audioSource.Play();
            Invoke("ShowArrow", broadcast.length); // ��� ���� �� ȭ��ǥ ǥ��
        }
    }

    void ShowArrow()
    {
        arrow.SetActive(true);
        Invoke("HideArrow", 20); // 20�� �� ȭ��ǥ ����
    }

    void HideArrow()
    {
        arrow.SetActive(false);
    }
}
