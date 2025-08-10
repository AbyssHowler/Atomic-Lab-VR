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
                labelText.color = Color.green; // Ŭ������ ���� �ʷϻ�
            }
            else
            {
                labelText.color = Color.black; // ���� Ŭ���� �� �� ���� ������
            }
        }
    }
}
