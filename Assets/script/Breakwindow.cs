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
    public GameObject fourthStep;
    public AudioClip emergencySound; // 비상벨 소리 오디오 클립
    private AudioSource audioSource; // AudioSource 컴포넌트

    void Start()
    {
        // AudioSource 컴포넌트를 게임 오브젝트에 추가하고 참조합니다.
        audioSource = gameObject.AddComponent<AudioSource>();
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
        fourthStep.SetActive(false);

        // 비상벨 소리 재생
        if (emergencySound != null)
        {
            audioSource.clip = emergencySound;
            audioSource.Play();
        }
    }
}
