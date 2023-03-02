using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Balloon : MonoBehaviour
{
    public int partsNeeded = 7; // the number of body parts needed to collect the balloon
    public GameObject[] bodyParts; // an array of the body parts that are needed to collect the balloon

    private PlayerController playerController; // a reference to the PlayerController script

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // find the PlayerController script in the scene
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerController.bodyParts >= partsNeeded && CheckBodyParts())
            {
                // if the player has enough body parts and they match the required ones, they can collect the balloon
                playerController.isFloating = true;
                Destroy(gameObject);
            }
        }
    }

    private bool CheckBodyParts()
    {
        foreach (GameObject bodyPart in bodyParts)
        {
            bool foundPart = false;

            foreach (bool partStatus in playerController.bodyPartStatus)
            {
                if (partStatus && bodyPart.CompareTag("BodyPart" + (Array.IndexOf(playerController.bodyPartStatus, partStatus) + 1)))
                {
                    foundPart = true;
                    break;
                }
            }

            if (!foundPart)
            {
                return false; // if a required body part is not found, return false
            }
        }

        return true; // if all required body parts are found, return true
    }
}
