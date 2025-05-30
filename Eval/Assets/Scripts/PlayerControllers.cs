using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;
    private string direction;
    private bool jump = false;
    private bool idJumping = false;
    [SerializeField] private float movementSpeed = 0.3f;
    [SerializeField] private float jumpForce = 7f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            direction = "left";
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = "right";
        }
        else
        {
            direction = null;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !idJumping)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (direction == "right")
        {
            rb.AddForce(new Vector2(movementSpeed, 0), ForceMode2D.Impulse);
        }
        else if (direction == "left")
        {
            rb.AddForce(new Vector2(-movementSpeed, 0), ForceMode2D.Impulse);
        }
        if (jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
            idJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            idJumping = false;
        }
    }
}
