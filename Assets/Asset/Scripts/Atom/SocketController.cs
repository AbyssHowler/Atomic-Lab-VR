using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SocketController : MonoBehaviour
{
    public XRSocketInteractor socket;
    public AtomManager parentAtom;

    void Awake()
    {
        socket.selectEntered.AddListener(OnObjectAttached);
    }

    void OnObjectAttached(SelectEnterEventArgs args)
    {
        Transform target = args.interactableObject.transform;
        GameObject targetObj = target.gameObject;

        var targetAtom = targetObj.GetComponent<AtomManager>();
        if (targetAtom == null || parentAtom == null) return;

        // 1. Grab 해제
        var grab = targetObj.GetComponent<XRGrabInteractable>();
        if (grab != null && grab.interactorsSelecting.Count > 0)
        {
            grab.interactionManager.SelectExit(grab.interactorsSelecting[0], grab);
        }

        // 2. 소켓 탐색
        XRSocketInteractor targetSocket = targetAtom.GetAvailableSocket();
        XRSocketInteractor selfSocket = parentAtom.GetAvailableSocket();

        if (targetSocket != null && selfSocket != null)
        {
            Vector3 fromDir = targetAtom.GetBondDirection(targetSocket);
            Vector3 toDir = -parentAtom.GetBondDirection(selfSocket);

            Quaternion correction = Quaternion.FromToRotation(fromDir, toDir);
            target.rotation = correction * target.rotation;

            Vector3 socketOffset = targetSocket.attachTransform.position - target.position;
            target.position = socket.attachTransform.position - correction * socketOffset;
        }
        else
        {
            target.position = socket.attachTransform.position;
            target.rotation = socket.attachTransform.rotation;
        }

        // 3. 충돌 제거
        Collider[] socketCols = socket.GetComponentsInChildren<Collider>();
        Collider[] targetCols = targetObj.GetComponentsInChildren<Collider>();
        foreach (var col1 in socketCols)
        {
            foreach (var col2 in targetCols)
            {
                Physics.IgnoreCollision(col1, col2);
            }
        }

        // 4. 부모 설정
        target.SetParent(parentAtom.transform);

        // 5. 컴포넌트 제거
        if (grab != null) Destroy(grab);
        var baseInteractable = targetObj.GetComponent<XRBaseInteractable>();
        if (baseInteractable != null) Destroy(baseInteractable);

        var rb = targetObj.GetComponent<Rigidbody>();
        if (rb != null) Destroy(rb);

        // 6. 전자 수 소모
        int bonding = Mathf.Min(1, Mathf.Min(parentAtom.availableElectrons, targetAtom.availableElectrons));
        parentAtom.ConsumeElectrons(bonding);
        targetAtom.ConsumeElectrons(bonding);

        // 7. 화학식 조합
        parentAtom.AddBondedAtom(targetAtom);
    }
}
