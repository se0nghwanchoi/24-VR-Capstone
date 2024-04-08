using UnityEngine;

public class ParticleTriggerHandler : MonoBehaviour
{
    public GameObject Explosion;   // Explosion prefab
    public Transform Firepos1;    // Explosion prefab이 생성될 transform
    public GameObject SecondFire; // SecondFire GameObject

    private bool hasExploded = false;

    void OnParticleTrigger()
    {
        if (!hasExploded)
        {
            //Debug.Log("파티클 충돌"); // 충돌 확인용 
            Invoke("ExplodeAndActivateSecondFire", 1.5f); // 1.5초 후에 폭발 생성 및 SecondFire 활성화 예약

            hasExploded = true; // 폭발한 후에는 다시 폭발하지 않도록 설정
        }
    }

    void ExplodeAndActivateSecondFire()
    {
        GameObject explosionInstance = Instantiate(Explosion, Firepos1.position, Firepos1.rotation); //폭발 생성
        Destroy(explosionInstance, 1.5f); // 1.5초 후에 폭발 제거

        SecondFire.SetActive(true); // SecondFire 활성화
    }
}
