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
        // 현재 위치에서 이전 위치를 뺀 뒤, 시간으로 나눠 속도 계산
        Vector3 deltaPosition = transform.position - lastPosition;
        velocity = deltaPosition / Time.deltaTime;

        // 로컬 속도 변환 (캐릭터 기준 전후좌우)
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        // 애니메이터에 전달
        animator.SetFloat("VX", localVelocity.x);
        animator.SetFloat("VZ", localVelocity.z);

        // 현재 위치 저장
        lastPosition = transform.position;
    }
}
