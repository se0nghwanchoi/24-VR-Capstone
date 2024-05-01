using UnityEngine;
using UnityEngine.UI;

public class ValidateInput : MonoBehaviour
{
    public InputField inputField; // �Է� �ʵ�
    public Button submitButton;   // ���� ��ư

    void Start()
    {
        UpdateButtonState(); // �ʱ� ��ư ���� ������Ʈ
        inputField.onValueChanged.AddListener(delegate { UpdateButtonState(); });
    }

    // �Է� �ʵ��� ���� ���� ��ư�� Ȱ��ȭ ���¸� ������Ʈ�ϴ� �޼ҵ�
    void UpdateButtonState()
    {
        // �Է� �ʵ��� �ؽ�Ʈ�� ��� �ְų� null�̸� ��ư�� ��Ȱ��ȭ
        submitButton.interactable = !string.IsNullOrEmpty(inputField.text);
    }
}
