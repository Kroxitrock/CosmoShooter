using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour
{

    private BoxCollider2D groundCollider;       //This stores a reference to the collider attached to the Ground.
    private float groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.

   
    //Update runs once per frame
    private void Update()
    {
        if(!CharacterController.poused)
        if (transform.position.y > -10.17f)
            RepositionBackground();
        else transform.position = new Vector2(0,10.17f);
    }

    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {
        //This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
        Vector2 groundOffSet = new Vector2(0, -5f * 0.005f);

        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}