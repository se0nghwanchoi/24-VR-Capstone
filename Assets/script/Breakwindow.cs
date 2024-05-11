using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Breakwindow : MonoBehaviour
{
    public XRSimpleInteractable simpleInteractable; // 참조할 XRInteractable
    public Transform createPoint;
    public GameObject window;
    public Transform destroyEffectPrefab;
  
    public AudioClip emergencySound; // 비상벨 소리 오디오 클립
    private AudioSource audioSource; // AudioSource 컴포넌트

    void Start()
    {
        // AudioSource 컴포넌트를 게임 오브젝트에 추가하고 참조합니다.
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // 소리를 반복 재생하도록 설정 [변경됨: 무한 반복 재생을 위해 loop 속성을 true로 설정]
    }

    void OnEnable()
    {
        simpleInteractable.selectEntered.AddListener(HandleSelectEntered);
    }

    void OnDisable()
    {
        simpleInteractable.selectEntered.RemoveListener(HandleSelectEntered);
    }

    private void HandleSelectEntered(SelectEnterEventArgs arg)
    {
        Destroy(window);
        // 파티클 생성
        Transform particleInstance = Instantiate(destroyEffectPrefab, createPoint.position, createPoint.rotation, createPoint);
       

        // 비상벨 소리 재생
        if (emergencySound != null && !audioSource.isPlaying) // [변경됨: audioSource.isPlaying을 체크하여 이미 재생 중인 소리는 중복 재생되지 않도록 함]
        {
            audioSource.clip = emergencySound;
            audioSource.Play();
        }
    }
}