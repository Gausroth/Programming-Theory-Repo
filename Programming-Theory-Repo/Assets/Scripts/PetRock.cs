using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetRock : MonoBehaviour
{
    new public string name { get; private set; } // ENCAPSULATION
    public string type { get; private set; } // ENCAPSULATION
    public int value { get; private set; } // ENCAPSULATION

    private void Start()
    {
        RenamePetRock();
    }
    public void RenamePetRock() // ABSTRACTION
    {
        Debug.Log("Rename Your Pet Rock");
        //TODO: Ask user to name pet rock.
    }
}
