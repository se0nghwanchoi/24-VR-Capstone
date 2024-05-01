using UnityEngine;
using UnityEngine.UI;

public class ValidateInput : MonoBehaviour
{
    public InputField inputField; // 입력 필드
    public Button submitButton;   // 제출 버튼

    void Start()
    {
        UpdateButtonState(); // 초기 버튼 상태 업데이트
        inputField.onValueChanged.AddListener(delegate { UpdateButtonState(); });
    }

    // 입력 필드의 값에 따라 버튼의 활성화 상태를 업데이트하는 메소드
    void UpdateButtonState()
    {
        // 입력 필드의 텍스트가 비어 있거나 null이면 버튼을 비활성화
        submitButton.interactable = !string.IsNullOrEmpty(inputField.text);
    }
}
