using UnityEngine;

public class MovingPlatformTrigger : MonoBehaviour
{
    public Transform platform;          // ������
    public Transform targetPosition;    // �ړI�n�i�����ړ�����ꏊ�j
    public float speed = 2f;

    private bool shouldMove = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldMove = true;
        }
    }

    void Update()
    {
        if (shouldMove && platform != null && targetPosition != null)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPosition.position, speed * Time.deltaTime);
        }
    }
}
