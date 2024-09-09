using UnityEngine;

public class Heroine : MonoBehaviour
{

    public float jumpForce = 5.0f;
    public float diveForce = 20.0f;
    private HeroineState _state;

    private void Start()
    {
        _state = new StandingState();
        Debug.Log("Start");
        _state.Enter(this);
    }

    private void Update()
    {
        // Only process input and state changes for the original heroine
        //If compare tag not here, this will create a state machine
        //within a state machine
        if (gameObject.CompareTag("Heroine"))
        {
            HeroineState newState = _state.HandleInput(this);
            if (newState != null)
            {
                _state.Exit(this);
                _state = newState;
                _state.Enter(this);
            }
            _state.Update(this);
        }
    }

    //this part still confuses me, asked CHatGPT
    //Had to implement because couldn't exit jumping state
    public void ChangeState(HeroineState newState)
    {
        _state.Exit(this); // Exit the current state
        _state = newState; // Set the new state
        _state.Enter(this); // Enter the new state
    }
}