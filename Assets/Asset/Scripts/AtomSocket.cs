using UnityEngine;

public class AtomSocket : MonoBehaviour

{
    public Transform electron; // Electron Transform
    public Transform electronAttachPoint; // Socket�� AttachPoint
    public Collider socketTrigger; // Socket Trigger Collider

    public Rigidbody atomRigidbody; // Atom Rigidbody
    public Rigidbody electronRigidbody; // Electron Rigidbody

    private void OnTriggerEnter(Collider other)
    {
        if (other == socketTrigger)
        {
            Debug.Log("Socket ������. Electron�� Atom ����.");

            // Electron�� AttachPoint ��ġ�� �̵�, ȸ�� ����
            electron.position = electronAttachPoint.position;
            electron.rotation = electronAttachPoint.rotation;

            // Electron Rigidbody�� Kinematic���� ������ ����
            if (electronRigidbody != null)
                electronRigidbody.isKinematic = true;

            // Atom Rigidbody�� Kinematic���� ������ ����
            if (atomRigidbody != null)
                atomRigidbody.isKinematic = true;
        }
    }
}
