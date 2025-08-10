using UnityEngine;

public class CharacterVelocity : MonoBehaviour
{
    public Animator animator;

    private Vector3 lastPosition;
    private Vector3 velocity;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        // ���� ��ġ���� ���� ��ġ�� �� ��, �ð����� ���� �ӵ� ���
        Vector3 deltaPosition = transform.position - lastPosition;
        velocity = deltaPosition / Time.deltaTime;

        // ���� �ӵ� ��ȯ (ĳ���� ���� �����¿�)
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        // �ִϸ����Ϳ� ����
        animator.SetFloat("VX", localVelocity.x);
        animator.SetFloat("VZ", localVelocity.z);

        // ���� ��ġ ����
        lastPosition = transform.position;
    }
}
