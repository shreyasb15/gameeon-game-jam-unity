using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualPlatformsController : MonoBehaviour
{
    public GameObject platform1;
    public GameObject platform2;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isControllingPlatform1 = true;
    private bool canJump1 = true;
    private bool isGrounded1 = false;

    private bool canJump2 = true;
    private bool isGrounded2 = false;

    void Update()
    {
        // Switch control between platforms on Left Shift press
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SwitchControl();
        }

        // Move the actively controlled platform
        float moveInput = Input.GetAxis("Horizontal") * moveSpeed;
        if (isControllingPlatform1)
        {
            MovePlatform(platform1, moveInput);
            HandleJumpInput(platform1, ref canJump1, ref isGrounded1);
        }
        else
        {
            MovePlatform(platform2, moveInput);
            HandleJumpInput(platform2, ref canJump2, ref isGrounded2);
        }
    }

    void SwitchControl()
    {
        // Toggle control between platforms
        isControllingPlatform1 = !isControllingPlatform1;

        // Lock the inactive platform in place
        if (isControllingPlatform1)
        {
            platform2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            platform1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            canJump1 = true;
            canJump2 = false;
        }
        else
        {
            platform1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            platform2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            canJump1 = false;
            canJump2 = true;
        }

        // Reset jump ability when switching platforms
        //canJump1 = isGrounded1;
        //canJump2 = isGrounded2;
    }

    void MovePlatform(GameObject platform, float moveInput)
    {
        // Move the platform horizontally based on input
        Vector3 currentPosition = platform.transform.position;
        currentPosition.x += moveInput * Time.deltaTime;
        platform.transform.position = currentPosition;
    }

    void HandleJumpInput(GameObject platform, ref bool canJump, ref bool isGrounded)
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            Jump(platform);
            canJump = false;
        }
    }

    void Jump(GameObject platform)
    {
        // Apply upward force for jumping
        platform.GetComponent<Rigidbody2D>().velocity = new Vector2(platform.GetComponent<Rigidbody2D>().velocity.x, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the platforms are grounded
        if (collision.gameObject == platform1)
        {
            isGrounded1 = true;
            canJump1 = true;
        }
        else if (collision.gameObject == platform2)
        {
            isGrounded2 = true;
            canJump2 = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Update grounded status when leaving the ground
        if (collision.gameObject == platform1)
        {
            isGrounded1 = false;
        }
        else if (collision.gameObject == platform2)
        {
            isGrounded2 = false;
        }
    }
}
