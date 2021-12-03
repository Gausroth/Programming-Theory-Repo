using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : Interactable // INHERITANCE
{
    public GameObject forgePanel;

    public string oreType1;
    public string oreType2;
    public override void Interact() // POLYMORPHISM
    {
        base.Interact();

        //Open UI
        forgePanel.SetActive(true);
    }

    //Forge Button
    public void ForgePetRock()
    {
        //Forge the pet rock
    }
}
