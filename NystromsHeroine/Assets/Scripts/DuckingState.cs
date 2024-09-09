using UnityEngine;

public class DuckingState : HeroineState
{
    private Vector3 normalScale;
    private Vector3 newScale;

    public DuckingState()
    {
        Debug.Log("Duck");
    }

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Enter Ducking");

        //set normal scale
        normalScale = heroine.transform.localScale;

        // Set new scale
        newScale = new Vector3(normalScale.x, normalScale.y * 0.5f, normalScale.z);
        //Make cube short with new scale
        heroine.transform.localScale = newScale;
    }

    public override void Exit(Heroine heroine)
    {
        Debug.Log("Exit Ducking");
        //return back to normal scale
        heroine.transform.localScale = normalScale;
    }

    public override HeroineState HandleInput(Heroine heroine)
    {
        // Allow jumping only for the original heroine
        if (heroine.gameObject.tag != "Heroine")
        {
            return null;
        }

        // Check if= player releases shift
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            return new StandingState(); // Go to standing sg
        }
        return null;
    }

    public override void Update(Heroine heroine)
    {

    }

}