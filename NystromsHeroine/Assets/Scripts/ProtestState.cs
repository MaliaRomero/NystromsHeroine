using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtestState : HeroineState
{
    private GameObject signObject;
    private GameObject signTextObject;


    public override void Enter(Heroine heroine)
    {
        Debug.Log("Entering ProtestState.");

        // Find the Sign object by tag
        //For future reference- unpack prefab and make sure
        //you have render, not actually turning off full object

        signObject = GameObject.FindGameObjectWithTag("Sign");

        //Find Sign
        if (signObject != null)
        {
            Debug.Log("Sign object found.");

            MeshRenderer signRenderer = signObject.GetComponent<MeshRenderer>();

            if (signRenderer != null)
            {
                signRenderer.enabled = true; // Enable the Mesh Renderer
            }
            else
            {
                Debug.Log("Uh oh D: ");
            }
        }
        else
        {
            Debug.Log("Oops no sign");
        }

        // Find text
        signTextObject = signObject.transform.Find("Text")?.gameObject;

        if (signTextObject == null)
        {
            Debug.Log("Uh oh Text");
        }
        else
        {
            // Enable the sign's Text Mesh Renderer
            MeshRenderer textRenderer = signTextObject.GetComponent<MeshRenderer>();
            if (textRenderer != null)
            {
                Debug.Log("Enabling Sign Text Renderer.");
                textRenderer.enabled = true; // Enable the Text Mesh Renderer
            }
            else
            {
                Debug.Log("Uh oh: MeshRenderer not found on Sign Text object.");
            }
        }

    }

    public override void Exit(Heroine heroine)
    {
        Debug.Log("Exiting ProtestState.");
    }


    public override HeroineState HandleInput(Heroine heroine)
    {

        //Check if cube should be in protest state
        if (Input.GetKeyDown(KeyCode.R))
        {
            return new RevolutionState(); // Transition to Revolution
        }
        return null;
    }
}
