using UnityEngine;

public class MovingPlatformWhileOn : MonoBehaviour
{
    public Transform platform;          // ��������
    public Transform targetPosition;    // �ړ���
    public float speed = 2f;

    private bool playerOnPlatform = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    private void Update()
    {
        if (playerOnPlatform && platform != null && targetPosition != null)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPosition.position, speed * Time.deltaTime);
        }
    }
}
