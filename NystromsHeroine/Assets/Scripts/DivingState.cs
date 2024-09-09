using UnityEngine;

public class DivingState : HeroineState
{
    
    public override HeroineState HandleInput(Heroine heroine)
    {

        if (IsGrounded(heroine))
        {
            return new StandingState(); // If grounded return to standing
        }

        return null;
    }

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Entering DivingState.");

        Rigidbody rb = heroine.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(rb.velocity.x, -heroine.diveForce, rb.velocity.z);
        }
    }

    public override void Exit(Heroine heroine)
    {
        Debug.Log("Exiting DivingState.");
    }

    private bool IsGrounded(Heroine heroine)
    {
        return Physics.Raycast(heroine.transform.position, Vector3.down, 1.0f);
    }
}