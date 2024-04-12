using UnityEngine;

public class ParticleTriggerHandler : MonoBehaviour
{
    public GameObject Explosion;   // Explosion prefab
    public Transform Firepos1;    // Explosion prefab이 생성될 transform
    public GameObject SecondFire; // SecondFire GameObject
    public GameObject ThirdStep; // 3번째 스텝 화살표 
    public AudioClip broadcast; // 안내 방송 오디오 클립

    private bool hasExploded = false;
    private AudioSource audioSource; // 오디오 소스 컴포넌트

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 가져옴
    }

    void OnParticleTrigger()
    {
        if (!hasExploded)
        {
            Invoke("ExplodeAndActivateSecondFire", 1.5f); // 1.5초 후에 폭발 생성 및 SecondFire 활성화 예약
            PlayAudioAndActivateThirdStep();
            hasExploded = true; // 폭발한 후에는 다시 폭발하지 않도록 설정
        }
    }

    void ExplodeAndActivateSecondFire()
    {
        GameObject explosionInstance = Instantiate(Explosion, Firepos1.position, Firepos1.rotation); //폭발 생성
        Destroy(explosionInstance, 1.5f); // 1.5초 후에 폭발 제거

        SecondFire.SetActive(true); // SecondFire 활성화
        ThirdStep.SetActive(true); //ThirdStep 활성화
    }

    void PlayAudioAndActivateThirdStep()
    {
        audioSource.clip = broadcast;
        audioSource.Play();
        Invoke("DeactivateThirdStep", 20); // 20초 후에 ThirdStep 비활성화
    }

    void DeactivateThirdStep()
    {
        ThirdStep.SetActive(false); // ThirdStep 비활성화
    }
}
