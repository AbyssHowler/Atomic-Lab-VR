using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    public GameObject targetObject; // 비활성화할 오브젝트

    public void DisableTarget()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
