using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetTowel : MonoBehaviour
{
    public AudioClip broadcast; // 안내 방송 오디오 클립
    public Material blueMaterial; // 파란색 머티리얼을 지정할 public 변수 추가
    public GameObject fourthStep; // FourthStep 게임 오브젝트 추가
    private AudioSource audioSource; // AudioSource 컴포넌트

    void Start()
    {
        // AudioSource 컴포넌트를 게임 오브젝트에 추가하고 참조합니다.
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // 충돌이 시작되었을 때 호출됨
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체의 태그가 "Water"인 경우에만 처리
        if (collision.gameObject.CompareTag("Water"))
        {
            // 디버그 로그 출력
            Debug.Log("물에 충돌했습니다!");

            // 수건의 머티리얼을 파란색으로 변경
            GetComponent<Renderer>().material = blueMaterial;

            // FourthStep 활성화
            fourthStep.SetActive(true);

            // 2초 뒤에 오디오 재생
            if (audioSource != null && broadcast != null)
            {
                Invoke("PlayDelayedAudio", 2f);
            }
        }
    }

    // 오디오를 지연시켜 재생하는 함수
    void PlayDelayedAudio()
    {
        audioSource.clip = broadcast;
        audioSource.Play();
    }
}
