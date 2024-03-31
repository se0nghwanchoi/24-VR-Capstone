using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFinished : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject arrow; // ȭ��ǥ GameObject

    void Start()
    {
        arrow.SetActive(false); // ���� �� ȭ��ǥ ��Ȱ��ȭ
        StartCoroutine(WaitForAudioEnd());
    }

    IEnumerator WaitForAudioEnd()
    {
        yield return new WaitWhile(() => audioSource.isPlaying); // ������� ����Ǵ� ���� ���
        arrow.SetActive(true); // ����� ��� ������ ȭ��ǥ Ȱ��ȭ
    }
}