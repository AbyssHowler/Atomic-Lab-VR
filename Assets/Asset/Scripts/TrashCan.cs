using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public AudioClip destroySound; // 파괴 사운드
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>(); // 없으면 자동 추가
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("element"))
        {
            Debug.Log("충돌한 오브젝트: " + other.name);

            // 사운드 재생
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
