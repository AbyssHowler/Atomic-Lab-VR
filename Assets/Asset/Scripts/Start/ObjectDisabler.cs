using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    public GameObject targetObject; // ��Ȱ��ȭ�� ������Ʈ

    public void DisableTarget()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
