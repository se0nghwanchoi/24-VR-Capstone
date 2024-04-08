using UnityEngine;

public class ParticleTriggerHandler : MonoBehaviour
{
    public GameObject Explosion;  // Explosion prefab
    public Transform Firepos1;    // Explosion prefab�� ������ transform
    public GameObject Fire;       // Fire GameObject

    private bool hasExploded = false;

    void OnParticleTrigger()
    {
        if (!hasExploded)
        {
            //Debug.Log("��ƼŬ �浹"); // �浹 Ȯ�ο� 
            Invoke("ExplodeAndDestroy", 1.5f); // 2�� �Ŀ� ���� ���� �� ���� ����

            hasExploded = true; // ������ �Ŀ��� �ٽ� �������� �ʵ��� ����
        }
    }

    void ExplodeAndDestroy()
    {
        GameObject explosionInstance = Instantiate(Explosion, Firepos1.position, Firepos1.rotation); //���� ����
        Destroy(explosionInstance, 1.5f); // 2�� �Ŀ� ���� ����
    }
}
