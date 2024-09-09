using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingState : HeroineState
{
    private GameObject signObject;
    private GameObject signTextObject;
    private GameObject crownObject;
    private Vector3 normalScale;
    private Vector3 newScale;

    public override void Enter(Heroine heroine)
    {
        Debug.Log("Entering KingState.");

        // Change the original heroine's color to gold
        Renderer heroineRenderer = heroine.GetComponent<Renderer>();
        if (heroineRenderer != null)
        {
            heroineRenderer.material.color = Color.yellow; // Change to gold
        }

        //set normal scale
        normalScale = heroine.transform.localScale;

        // Set new scale
        newScale = new Vector3(normalScale.x *4f, normalScale.y *4f, normalScale.z *4f);
        //Make cube short with new scale
        heroine.transform.localScale = newScale;

        //Find sign
        signObject = GameObject.FindGameObjectWithTag("Sign");

        // Find text
        signTextObject = signObject.transform.Find("Text")?.gameObject;

        crownObject = GameObject.FindGameObjectWithTag("Crown");

        // Enable the crown renderer
        if (crownObject != null)
        {
            MeshRenderer crownRenderer = crownObject.GetComponent<MeshRenderer>();
            if (crownRenderer != null)
            {
                crownRenderer.enabled = true; // Enable the Mesh Renderer
            }
        }


        //Disables the renderers
        if (signObject != null)
        {
            MeshRenderer signRenderer = signObject.GetComponent<MeshRenderer>();
            if (signRenderer != null)
            {
                signRenderer.enabled = false; // Disable the Renderer
            }

            // Disable child text render
            if (signTextObject != null)
            {
                MeshRenderer textRenderer = signTextObject.GetComponent<MeshRenderer>();
                if (textRenderer != null)
                {
                    textRenderer.enabled = false; // Disable the Text Mesh Renderer
                }
            }


        }
    }

    public override void Exit(Heroine heroine)
    {
        Debug.Log("Exiting King State.");

        heroine.transform.localScale = normalScale;

        GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (GameObject clone in clones)
        {
            GameObject.Destroy(clone);
        }

        // Disable crown renderer
        crownObject = GameObject.FindGameObjectWithTag("Crown");
        if (crownObject != null)
        {
            MeshRenderer crownRenderer = crownObject.GetComponent<MeshRenderer>();
            if (crownRenderer != null)
            {
                crownRenderer.enabled = false; // Disable the Renderer
            }
        }
    }

    public override HeroineState HandleInput(Heroine heroine)
    {
        //Check if cube should go back to standing state
        if (Input.GetKeyDown(KeyCode.S))
        {
            return new StandingState(); // Transition back to standing
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            return null;
        }
        return null;

    }
}