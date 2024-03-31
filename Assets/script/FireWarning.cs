using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 추가

public class FireWarning : MonoBehaviour
{
    public TextMeshProUGUI warningText; // 경고 텍스트에 대한 참조
    public float displayTime = 5.0f; // 텍스트를 표시할 시간 (초)

    void Start()
    {
        warningText.gameObject.SetActive(false); // 시작 시 경고 텍스트를 숨깁니다.
        ShowWarning(); // 경고 메시지를 표시하는 함수 호출
    }

    public void ShowWarning()
    {
        warningText.gameObject.SetActive(true); // 경고 텍스트를 활성화합니다.
        Invoke("HideWarning", displayTime); // displayTime 후에 HideWarning 함수 호출
    }

    void HideWarning()
    {
        warningText.gameObject.SetActive(false); // 경고 텍스트를 비활성화합니다.
    }
}
