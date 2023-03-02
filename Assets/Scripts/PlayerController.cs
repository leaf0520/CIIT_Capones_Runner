using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int bodyParts = 0;
    public bool[] bodyPartStatus = new bool[3]; // using a bool array to track which body parts are missing
    public bool isFloating = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            if (HasAllBodyParts())
            {
                isFloating = true; // if the player has all body parts, they will float
            }
            else
            {
                RegenerateBodyPart(); // if the player is missing a body part, it will regenerate
            }

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (bodyParts > 0)
            {
                bodyParts--; // if the player collides with an obstacle and has body parts, they lose one body part
                bodyPartStatus[bodyParts] = false; // setting the status of the missing body part to false
            }

            Destroy(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isFloating)
        {
            // apply force to make the player float
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Force);
        }
    }

    private bool HasAllBodyParts()
    {
        for (int i = 0; i < bodyPartStatus.Length; i++)
        {
            if (!bodyPartStatus[i])
            {
                return false; // if any body part is missing, return false
            }
        }

        return true; // if all body parts are present, return true
    }

    private void RegenerateBodyPart()
    {
        for (int i = 0; i < bodyPartStatus.Length; i++)
        {
            if (!bodyPartStatus[i])
            {
                bodyPartStatus[i] = true; // set the status of the missing body part to true
                break; // break out of the loop once a missing body part has been found
            }
        }
    }
}
