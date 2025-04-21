using UnityEngine;

public class Drop : MonoBehaviour
{
    public Transform player;               // プレイヤーのTransformをInspectorで設定
    public float triggerDistanceXZ = 0.5f; // XZ距離の許容範囲

    private Rigidbody rb;
    private bool hasDropped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;             // 最初は固定しておく
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
            rb.isKinematic = false;  // 落下させる
            hasDropped = true;
        }
    }
}
