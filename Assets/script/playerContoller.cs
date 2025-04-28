using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float player;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
        
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");

        // �ړ�����
        Vector3 move = new Vector3(moveX, 0, 0) * moveSpeed;
        Vector3 velocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(move.x, velocity.y, 0);

        // �����ύX����
        //if (moveX > 0.01f)
        //{
        //    transform.rotation = Quaternion.Euler(0, 90, 0); // �E����
        //}
        //else if (moveX < -0.01f)
        //{
        //    transform.rotation = Quaternion.Euler(0, -90, 0); // ������
        //}
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    
}

