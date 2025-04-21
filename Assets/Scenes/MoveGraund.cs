using UnityEngine;

public class MoveGraund : MonoBehaviour
{
    private Vector3 StagePos;

    private void Start()
    {
        StagePos = transform.position;
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 2.0f + StagePos.x, StagePos.y, StagePos.z);
    }
}
