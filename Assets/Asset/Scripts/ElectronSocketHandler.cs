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
        // 1. ���� ������Ʈ
        GameObject electron = args.interactableObject.transform.gameObject;

        // 2. ���ڰ� ���Ե� ���� ���� (��: Hydrogen)
        GameObject rootAtom = FindRootAtom(electron);

        if (rootAtom == null)
        {
            Debug.LogWarning("Root Atom not found!");
            return;
        }

        // 3. ���� ��ġ�� ���� �̵�
        rootAtom.transform.position = socket.attachTransform.position;
        rootAtom.transform.rotation = socket.attachTransform.rotation;

        // 4. �������� �ʵ��� ����
        Rigidbody rb = rootAtom.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;
    }

    private GameObject FindRootAtom(GameObject electron)
    {
        // Ŀ���� ���ؿ� ���� ���Ҹ� ã�� �Լ�
        // ��: 'BasicAtom' �±׸� ���� �θ� ������Ʈ ã��
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
