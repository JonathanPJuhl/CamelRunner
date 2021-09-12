using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10;
    float horizontalInput;
    [SerializeField] float leftAndRightMultiplier = 2;

    [SerializeField] Rigidbody rb;

    public float speedIncreasePerPoint = 0.1f;
    bool isAlive = true;

    private void FixedUpdate()
    {
        if (!isAlive) return;
        Vector3 forward = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 leftAndRight = transform.right * horizontalInput * speed * Time.fixedDeltaTime * leftAndRightMultiplier;
        rb.MovePosition(rb.position + forward + leftAndRight);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        isAlive = false;
        Invoke("Restart", 2);
        
    }
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
