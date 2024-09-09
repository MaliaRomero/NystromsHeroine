using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolutionState : HeroineState
{

    public override HeroineState HandleInput(Heroine heroine)
    {
        //Check if cube should be in march state
        if (Input.GetKeyDown(KeyCode.M))
        {
            return new MarchState(); // Transition to March
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            return null;
        }

        return null;

    }

    public override void Enter(Heroine heroine)
    {
        //makin' clones
        int numRows = 6; // Number of rows
        int numColumns = 10; // Number of columns
        float distance = 2.0f; // Distance between
        float distanceBehind = 5.0f; // Distance behind the original

        //offset
        float totalWidth = distance * (numColumns - 1);
        float totalHeight = distance * (numRows - 1);

        // Calculate the starting point
        Vector3 startPosition = heroine.transform.position - Vector3.forward * distanceBehind - new Vector3(totalWidth / 2, 0, totalHeight / 2);

        for (int row = 0; row < numRows; row++)
        {
            for (int column = 0; column < numColumns; column++)
            {
                GameObject clone = GameObject.Instantiate(heroine.gameObject);
                clone.tag = "Clone";//DO NOT DELETE
                Vector3 positionOffset = new Vector3(column * distance, 0, row * distance);
                clone.transform.position = startPosition + positionOffset;
            }
        }
    }


    public override void Exit(Heroine heroine)
    {
        Debug.Log("Exiting RevolutionState.");
    }
}
