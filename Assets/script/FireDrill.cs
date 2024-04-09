using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrill : MonoBehaviour
{
    public GameObject arrow; // 화살표 객체
    public AudioClip broadcast; // 안내 방송 오디오 클립
    private AudioSource audioSource; // 오디오 소스 컴포넌트

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        arrow.SetActive(false); // 초기에는 화살표를 숨깁니다.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 'Player' 태그를 가진 객체가 콜리더에 들어온 경우
        {
            audioSource.clip = broadcast;
            audioSource.Play();
            Invoke("ShowArrow", broadcast.length); // 방송 길이 후 화살표 표시
        }
    }

    void ShowArrow()
    {
        arrow.SetActive(true);
        Invoke("HideArrow", 20); // 20초 후 화살표 숨김
    }

    void HideArrow()
    {
        arrow.SetActive(false);
    }
}
