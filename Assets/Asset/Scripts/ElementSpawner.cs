using UnityEngine;

public class ElementSpawner : MonoBehaviour
{

    public GameObject elementPrefab;   // 생성할 프리팹
    public Transform spawnPoint;       // 생성 위치 (없으면 자기 위치 사용)
    public GameObject clearMessageUI;

    //private void OnMouseDown() // PC에서 호출될 함수
    //{
    //    Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.back * 1.5f;
    //    Instantiate(elementPrefab, spawnPosition, Quaternion.identity);
    //}

    public void SpawnElement() // VR에서 호출될 함수
    {
        Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.back * 1.5f;
        //Instantiate(elementPrefab, spawnPosition, Quaternion.identity);
        GameObject newAtom = Instantiate(elementPrefab, spawnPosition, Quaternion.identity);


        // AtomManager의 clearMessageUI에 직접 연결
        AtomManager atom = newAtom.GetComponent<AtomManager>();
        if (atom != null)
        {
            atom.clearMessageUI = clearMessageUI;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
