using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ���� ����
            Application.Quit();

            // �����Ϳ��� �׽�Ʈ�� ���� Play ��嵵 ����
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        }
    }
}
