using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyUI : MonoBehaviour
{
    public GameObject emergencyUI;  // 활성화할 UI 오브젝트의 참조
    private bool hasActivated = false;  // UI가 이미 활성화 되었는지 확인하는 플래그

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어가 콜라이더에 들어오고, UI가 아직 활성화되지 않았다면
        if (other.CompareTag("Player") && !hasActivated)
        {
            emergencyUI.SetActive(true);  // UI 오브젝트 활성화
            Debug.Log("대피 UI 생성");
            StartCoroutine(DeactivateAfterTime(8));  // 8초 후 오브젝트 비활성화
            hasActivated = true;  // 활성화 플래그를 true로 설정
        }
    }

    private IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        emergencyUI.SetActive(false);  // 오브젝트 비활성화
        Debug.Log("대피 UI 비활성화");
    }
}