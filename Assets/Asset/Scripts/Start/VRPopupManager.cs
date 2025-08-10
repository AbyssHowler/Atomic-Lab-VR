using UnityEngine;

public class VRPopupManager : MonoBehaviour
{
    public GameObject popupPanel; // UI ��ü �г� (�˾� â)

    void Start()
    {
        // ���� ���� �� �˾� �����ֱ�
        popupPanel.SetActive(true);
    }

    // ��ư���� �� �Լ��� ȣ���ϰ� �� ��
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}
