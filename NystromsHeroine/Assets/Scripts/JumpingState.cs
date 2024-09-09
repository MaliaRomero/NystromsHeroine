using UnityEngine;

public class JumpingState : HeroineState
{
    private bool isFalling;

    //added for no double jump, comment out for double jump
    public override HeroineState HandleInput(Heroine heroine)
    {
        // Allow jumping only for the original heroine
        if (heroine.gameObject.tag != "Heroine")
        {
            return null;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            return null;
        }


        // Check if cube should be in diving state
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return new DivingState(); // Transition to Diving
        }
        return null;
    }

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Entering JumpingState.");

        Rigidbody rb = heroine.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // reset velocity
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * heroine.jumpForce, ForceMode.Impulse);
        }

        isFalling = false; // Reset falling flag
    }

    public override void Exit(Heroine heroine)
    {
        Debug.Log("Exiting JumpingState.");
    }

    private bool IsGrounded(Heroine heroine)
    {
        float rayDistance = .9f;
        Vector3 rayOrigin = heroine.transform.position;

        // Check grounded using raycast
        return Physics.Raycast(rayOrigin, Vector3.down, rayDistance);
    }

    public override void Update(Heroine heroine)
    {
        Rigidbody rb = heroine.GetComponent<Rigidbody>();

        Debug.Log("Velocity: " + rb.velocity);

        // Check if falling
        if (!isFalling && rb.velocity.y <= 0)
        {
            isFalling = true;
        }

        // Check if we should transition back to StandingState
        if (isFalling && IsGrounded(heroine))
        {
            heroine.ChangeState(new StandingState());
        }
    }
}
