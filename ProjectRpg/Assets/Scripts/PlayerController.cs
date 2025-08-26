using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody _rb;
    private bool _isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(move * speed * Time.deltaTime, Space.World);


        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }
}
