using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchState : HeroineState
{
    private List<GameObject> clones = new List<GameObject>(); // List to hold all clones and the original Heroine
    private float moveSpeed = 5.0f; // Movement speed of the clones

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Entering MarchState.");
        //Chat gpt helpped with this
        // Clear previous entries and add the original Heroine
        clones.Clear();
        clones.Add(heroine.gameObject);

        // Find all clones by tag and add them to the list
        //If clones not added to list, creates a loop
        GameObject[] foundClones = GameObject.FindGameObjectsWithTag("Clone");
        clones.AddRange(foundClones);

        Debug.Log("Total units marching: " + clones.Count);
    }

    public override void Exit(Heroine heroine)
    {
        Debug.Log("Exiting MarchState.");
    }

    public override void Update(Heroine heroine)
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float verticalInput = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;

        // Move all clones and the original Heroine
        foreach (GameObject unit in clones)
        {
            if (unit != null)
            {
                unit.transform.Translate(movement);
            }
        }
    }

    public override HeroineState HandleInput(Heroine heroine)
    {
        //Check if cube should be in King state
        if (Input.GetKeyDown(KeyCode.K))
        {
            return new KingState(); // Transition to King
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            return null;
        }
        return null;
    }
}