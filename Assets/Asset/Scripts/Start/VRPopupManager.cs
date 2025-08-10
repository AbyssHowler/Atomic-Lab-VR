using UnityEngine;

public class VRPopupManager : MonoBehaviour
{
    public GameObject popupPanel; // UI 전체 패널 (팝업 창)

    void Start()
    {
        // 게임 시작 시 팝업 보여주기
        popupPanel.SetActive(true);
    }

    // 버튼에서 이 함수를 호출하게 할 것
    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}
