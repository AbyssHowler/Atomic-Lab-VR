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
            legacyTextUI.text = $"{label}를 만들어보세요";
        }
        else
        {
            legacyTextUI.text = "실험을 시작해보세요!";
        }
    }
}
