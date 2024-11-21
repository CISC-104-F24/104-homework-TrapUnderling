using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHW2 : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjustable speed for movement
    public float sprintSpeedMultiplier = 2f; // Multiplier for sprinting speed
    public float jumpForce = 5f; // Adjustable force for jumping
    private Rigidbody myRb; // Reference to the Rigidbody component
    public float maxJumpCharge = 10f; // Maximum jump power when charged
    public float jumpChargeRate = 2f; // Rate of charging jump power
    private bool isGrounded; // To check if the player is on the ground
    private float currentJumpPower; // Current jump power for charged jumps
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    // Ground check variables
    public LayerMask groundLayer; // Layer mask for defining ground
    public float groundCheckDistance = 0.1f; // Distance to check for ground

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the player
        myRb = GetComponent<Rigidbody>();
        currentJumpPower = jumpForce; // Initialize the current jump power
    }

    // Update is called once per frame
    void Update()
    {
        // Initialize movement direction as a zero vector
        Vector3 movementDirection = Vector3.zero; // The vector (0, 0, 0)

        // Define movement vectors based on the object's orientation
        Vector3 forward = transform.forward; // Forward direction
        Vector3 right = transform.right; // Right direction

        // Check for key presses
        if (Input.GetKey(KeyCode.W)) // Up
            movementDirection += forward; // Adds (0, 0, 1)

        if (Input.GetKey(KeyCode.S)) // Down
            movementDirection -= forward; // Subtracts (0, 0, 1)

        if (Input.GetKey(KeyCode.A)) // Left
            movementDirection -= right; // Subtracts (1, 0, 0)

        if (Input.GetKey(KeyCode.D)) // Right
            movementDirection += right; // Adds (1, 0, 0)

        // Check for sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementDirection *= sprintSpeedMultiplier; // Increase speed when sprinting
        }

        // Normalize the movement direction
        //movementDirection = movementDirection.normalized; // Ensures consistent speed

        // Move the player
        transform.position += movementDirection * moveSpeed * Time.deltaTime;

        // Check for jump input
        if (Input.GetKey(KeyCode.LeftControl)) // Hold for charged jump
        {
            ChargeJump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Jump key (Space)
        {
            Jump();
        }

        // Handle rotation
        if (Input.GetKey(KeyCode.Q)) // Rotate left
        {
            Rotate(-rotationSpeed); // Negative for left
        }

        if (Input.GetKey(KeyCode.E)) // Rotate right
        {
            Rotate(rotationSpeed); // Positive for right
        }

        // Update ground state
        //UpdateGroundState();
        isGrounded = true;
    }

    void ChargeJump()
    {
        // Increase the current jump power while holding Left Control
        if (currentJumpPower < maxJumpCharge)
        {
            currentJumpPower += jumpChargeRate * Time.deltaTime; // Increment charge
        }
    }

    void Jump()
    {
        // Apply upward force for jumping with charged power
        myRb.AddForce(Vector3.up * currentJumpPower, ForceMode.Impulse);
        currentJumpPower = jumpForce; // Reset jump power after jumping
    }

    void Rotate(float amount)
    {
        // Rotate the player around the y-axis
        transform.Rotate(0, amount * Time.deltaTime, 0);
    }

    void UpdateGroundState()
    {
        // Check if the player is touching the ground using a raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}