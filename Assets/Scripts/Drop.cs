using UnityEngine;

public class Drop : MonoBehaviour
{
    public Transform player;               // �v���C���[��Transform��Inspector�Őݒ�
    public float triggerDistanceXZ = 0.5f; // XZ�����̋��e�͈�

    private Rigidbody rb;
    private bool hasDropped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;             // �ŏ��͌Œ肵�Ă���
    }

    void Update()
    {
        if (hasDropped) return;

        Vector3 pos = transform.position;
        Vector3 playerPos = player.position;

        float dx = Mathf.Abs(pos.x - playerPos.x);
        float dz = Mathf.Abs(pos.z - playerPos.z);

        if (dx < triggerDistanceXZ && dz < triggerDistanceXZ && playerPos.y < pos.y)
        {
            rb.isKinematic = false;  // ����������
            hasDropped = true;
        }
    }
}
