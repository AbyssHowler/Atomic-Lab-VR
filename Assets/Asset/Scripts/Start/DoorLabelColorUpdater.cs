using UnityEngine;
using UnityEngine;
using TMPro;

public class DoorLabelColorUpdater : MonoBehaviour
{
    public TextMeshPro labelText;

    void Start()
    {
        if (labelText == null)
        {
            labelText = GetComponentInChildren<TextMeshPro>();
        }

        if (labelText != null)
        {
            string label = labelText.text.Trim();

            if (GameStateManager.clearedLabels.Contains(label))
            {
                labelText.color = Color.green; // 클리어한 문은 초록색
            }
            else
            {
                labelText.color = Color.black; // 아직 클리어 안 한 문은 검정색
            }
        }
    }
}
