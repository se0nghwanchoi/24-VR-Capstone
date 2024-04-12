using UnityEngine;

public class ParticleTriggerHandler : MonoBehaviour
{
    public GameObject Explosion;   // Explosion prefab
    public Transform Firepos1;    // Explosion prefab�� ������ transform
    public GameObject SecondFire; // SecondFire GameObject
    public GameObject ThirdStep; // 3��° ���� ȭ��ǥ 
    public AudioClip broadcast; // �ȳ� ��� ����� Ŭ��

    private bool hasExploded = false;
    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource ������Ʈ�� ������
    }

    void OnParticleTrigger()
    {
        if (!hasExploded)
        {
            Invoke("ExplodeAndActivateSecondFire", 1.5f); // 1.5�� �Ŀ� ���� ���� �� SecondFire Ȱ��ȭ ����
            PlayAudioAndActivateThirdStep();
            hasExploded = true; // ������ �Ŀ��� �ٽ� �������� �ʵ��� ����
        }
    }

    void ExplodeAndActivateSecondFire()
    {
        GameObject explosionInstance = Instantiate(Explosion, Firepos1.position, Firepos1.rotation); //���� ����
        Destroy(explosionInstance, 1.5f); // 1.5�� �Ŀ� ���� ����

        SecondFire.SetActive(true); // SecondFire Ȱ��ȭ
        ThirdStep.SetActive(true); //ThirdStep Ȱ��ȭ
    }

    void PlayAudioAndActivateThirdStep()
    {
        audioSource.clip = broadcast;
        audioSource.Play();
        Invoke("DeactivateThirdStep", 20); // 20�� �Ŀ� ThirdStep ��Ȱ��ȭ
    }

    void DeactivateThirdStep()
    {
        ThirdStep.SetActive(false); // ThirdStep ��Ȱ��ȭ
    }
}
