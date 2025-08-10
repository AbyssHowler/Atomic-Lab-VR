using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public string doorLabel; // ¿¹: "H2O", "CO2", "NH3"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameStateManager.EnteredDoorLabel = doorLabel;
            SceneManager.LoadScene("Lab");
        }
    }
}
