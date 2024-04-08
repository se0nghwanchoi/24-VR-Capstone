using UnityEngine;

public class ParticleTriggerHandler : MonoBehaviour
{
    public GameObject Explosion;   // Explosion prefab
    public Transform Firepos1;    // Explosion prefab�� ������ transform
    public GameObject SecondFire; // SecondFire GameObject

    private bool hasExploded = false;

    void OnParticleTrigger()
    {
        if (!hasExploded)
        {
            //Debug.Log("��ƼŬ �浹"); // �浹 Ȯ�ο� 
            Invoke("ExplodeAndActivateSecondFire", 1.5f); // 1.5�� �Ŀ� ���� ���� �� SecondFire Ȱ��ȭ ����

            hasExploded = true; // ������ �Ŀ��� �ٽ� �������� �ʵ��� ����
        }
    }

    void ExplodeAndActivateSecondFire()
    {
        GameObject explosionInstance = Instantiate(Explosion, Firepos1.position, Firepos1.rotation); //���� ����
        Destroy(explosionInstance, 1.5f); // 1.5�� �Ŀ� ���� ����

        SecondFire.SetActive(true); // SecondFire Ȱ��ȭ
    }
}
