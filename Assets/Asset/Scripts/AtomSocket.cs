using UnityEngine;

public class AtomSocket : MonoBehaviour

{
    public Transform electron; // Electron Transform
    public Transform electronAttachPoint; // Socket의 AttachPoint
    public Collider socketTrigger; // Socket Trigger Collider

    public Rigidbody atomRigidbody; // Atom Rigidbody
    public Rigidbody electronRigidbody; // Electron Rigidbody

    private void OnTriggerEnter(Collider other)
    {
        if (other == socketTrigger)
        {
            Debug.Log("Socket 감지됨. Electron과 Atom 고정.");

            // Electron을 AttachPoint 위치로 이동, 회전 고정
            electron.position = electronAttachPoint.position;
            electron.rotation = electronAttachPoint.rotation;

            // Electron Rigidbody를 Kinematic으로 변경해 고정
            if (electronRigidbody != null)
                electronRigidbody.isKinematic = true;

            // Atom Rigidbody도 Kinematic으로 변경해 고정
            if (atomRigidbody != null)
                atomRigidbody.isKinematic = true;
        }
    }
}
