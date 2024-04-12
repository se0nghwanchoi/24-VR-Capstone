using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetTowel : MonoBehaviour
{
    public AudioClip broadcast; // �ȳ� ��� ����� Ŭ��
    private AudioSource audioSource; // AudioSource ������Ʈ

    void Start()
    {
        // AudioSource ������Ʈ�� ���� ������Ʈ�� �߰��ϰ� �����մϴ�.
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // �浹�� ���۵Ǿ��� �� ȣ���
    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� �±װ� "Water"�� ��쿡�� ó��
        if (collision.gameObject.CompareTag("Water"))
        {
            // ����� �α� ���
            Debug.Log("���� �浹�߽��ϴ�!");

            // 2�� �ڿ� ����� ���
            if (audioSource != null && broadcast != null)
            {
                Invoke("PlayDelayedAudio", 2f);
            }
        }
    }

    // ������� �������� ����ϴ� �Լ�
    void PlayDelayedAudio()
    {
        audioSource.clip = broadcast;
        audioSource.Play();
    }
}
