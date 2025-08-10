using UnityEngine;

public class ElementSpawner : MonoBehaviour
{

    public GameObject elementPrefab;   // ������ ������
    public Transform spawnPoint;       // ���� ��ġ (������ �ڱ� ��ġ ���)
    public GameObject clearMessageUI;

    //private void OnMouseDown() // PC���� ȣ��� �Լ�
    //{
    //    Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.back * 1.5f;
    //    Instantiate(elementPrefab, spawnPosition, Quaternion.identity);
    //}

    public void SpawnElement() // VR���� ȣ��� �Լ�
    {
        Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position + Vector3.back * 1.5f;
        //Instantiate(elementPrefab, spawnPosition, Quaternion.identity);
        GameObject newAtom = Instantiate(elementPrefab, spawnPosition, Quaternion.identity);


        // AtomManager�� clearMessageUI�� ���� ����
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
