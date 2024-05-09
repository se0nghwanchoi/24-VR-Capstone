using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetTowel : MonoBehaviour
{
    
    public Material blueMaterial; // 파란색 머티리얼을 지정할 public 변수 추가
   
    

    void Start()
    {
        
    }

    // 트리거로 충돌이 시작되었을 때 호출됨
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 물체의 태그가 "Water"인 경우에만 처리
        if (other.CompareTag("Water"))
        {
            // 디버그 로그 출력
            Debug.Log("물에 충돌했습니다!");

            // 수건의 머티리얼을 파란색으로 변경
            GetComponent<Renderer>().material = blueMaterial;

                      
        }
    }

   

}
