using UnityEngine;
using UnityEngine.UI;

public class boardText : MonoBehaviour
{
    public Text legacyTextUI;

    void Start()
    {
        string label = GameStateManager.EnteredDoorLabel;
        if (!string.IsNullOrEmpty(label))
        {
            legacyTextUI.text = $"{label}�� ��������";
        }
        else
        {
            legacyTextUI.text = "������ �����غ�����!";
        }
    }
}
