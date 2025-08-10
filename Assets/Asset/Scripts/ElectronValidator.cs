using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Collider))]
public class ElectronValidator : MonoBehaviour
{
    void Start()
    {
        var grab = GetComponent<XRGrabInteractable>();
        var rb = GetComponent<Rigidbody>();
        var col = GetComponent<Collider>();

        Debug.Log($"[ElectronValidator] {name}");
        Debug.Log($" - XRGrabInteractable: {(grab != null ? "OK" : "MISSING")}");
        Debug.Log($" - Rigidbody: {(rb != null ? "OK" : "MISSING")}, isKinematic: {(rb != null ? rb.isKinematic.ToString() : "N/A")}");
        Debug.Log($" - Collider: {(col != null ? "OK" : "MISSING")}, isTrigger: {(col != null ? col.isTrigger.ToString() : "N/A")}");
        Debug.Log($" - Interaction Layer Mask: {(grab != null ? grab.interactionLayers.ToString() : "N/A")}");
    }
}
