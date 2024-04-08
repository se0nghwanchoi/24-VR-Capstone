using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventController : MonoBehaviour
{
    public AudioSource audioSource; // 안내 방송용 AudioSource
    public AudioClip arrivalClip; // 재생할 오디오 클립
    public GameObject arrow; // 화살표 GameObject
    private bool hasTriggered = false; // 이벤트가 이미 발생했는지 추적하는 변수

    private void Start()
    {
        arrow.SetActive(false); // 시작 시 화살표 비활성화
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);
        // 플레이어 태그를 가진 오브젝트가 트리거에 진입하고, 이벤트가 아직 발생하지 않았다면
        if (other.CompareTag("Player") && !hasTriggered)
        {
            StartCoroutine(PlayAudioAndShowArrow());
            hasTriggered = true; // 이벤트 발생 표시
        }
    }

    IEnumerator PlayAudioAndShowArrow()
    {


        Debug.Log("오디오 재생"); // 오디오 재생 로그
        audioSource.PlayOneShot(arrivalClip); // 안내 방송 재생
        yield return new WaitForSeconds(arrivalClip.length); // 오디오 클립 길이만큼 대기
        Debug.Log("화살표 활성화"); // 화살표 활성화 로그
        arrow.SetActive(true); // 화살표 활성화
        yield return new WaitForSeconds(20); // 20초 동안 대기
        arrow.SetActive(false); // 화살표 비활성화
    }
}
