using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ElectronSocketHandler : MonoBehaviour
{
    XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        if (socket != null)
            socket.selectEntered.AddListener(OnElectronAttached);
    }

    private void OnDisable()
    {
        if (socket != null)
            socket.selectEntered.RemoveListener(OnElectronAttached);
    }

    private void OnElectronAttached(SelectEnterEventArgs args)
    {
        // 1. 전자 오브젝트
        GameObject electron = args.interactableObject.transform.gameObject;

        // 2. 전자가 포함된 상위 원소 (예: Hydrogen)
        GameObject rootAtom = FindRootAtom(electron);

        if (rootAtom == null)
        {
            Debug.LogWarning("Root Atom not found!");
            return;
        }

        // 3. 소켓 위치로 원자 이동
        rootAtom.transform.position = socket.attachTransform.position;
        rootAtom.transform.rotation = socket.attachTransform.rotation;

        // 4. 움직이지 않도록 고정
        Rigidbody rb = rootAtom.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;
    }

    private GameObject FindRootAtom(GameObject electron)
    {
        // 커스텀 기준에 따라 원소를 찾는 함수
        // 예: 'BasicAtom' 태그를 가진 부모 오브젝트 찾기
        Transform current = electron.transform;
        while (current != null)
        {
            if (current.CompareTag("BasicAtom"))
                return current.gameObject;

            current = current.parent;
        }

        return null;
    }
}
