using UnityEngine;

public class StandingState : HeroineState
{
    public override HeroineState HandleInput(Heroine heroine)
    {
        //While holding shift, ducking.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return new DuckingState(); // Go to ducking
        }

        if (Input.GetKey(KeyCode.Space))
        {
            return new JumpingState();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("p");
            return new ProtestState();
        }

        return null;
    }

    public override void Enter(Heroine heroine)
    {
        Renderer heroineRenderer = heroine.GetComponent<Renderer>();
        if (heroineRenderer != null)
        {
            heroineRenderer.material.color = Color.gray; // Change to white
        }
        Debug.Log("StandingState, LShift for ducking");


    }

    public override void Exit(Heroine heroine)
    {
        Debug.Log("Exit Standing");
    }
}