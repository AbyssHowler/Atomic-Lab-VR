using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public AudioClip destroySound; // �ı� ����
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>(); // ������ �ڵ� �߰�
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("element"))
        {
            Debug.Log("�浹�� ������Ʈ: " + other.name);

            // ���� ���
            if (destroySound != null && audioSource != null)
                audioSource.PlayOneShot(destroySound);

            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
