using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forge : Interactable // INHERITANCE
{
    public GameObject forgePanel, stonePetRock, tinPetRock, copperPetRock, bronzePetRock;

    public HUD hud;

    string forgeOreType1, forgeOreType2;

    Vector3 spawnPosition = new Vector3(0, 0.25f, -6);

    protected override void Update()
    {
        base.Update();
        if (player == null)
        {
            CloseUI();
        }
    }
    public override void Interact() // POLYMORPHISM
    {
        base.Interact();

        forgePanel.SetActive(true);
    }

    public void CloseUI() // ABSTRACTION
    {
        forgePanel.SetActive(false);
    }

    //Forge Button
    public void ForgePetRock() // ABSTRACTION
    {
        if (forgeOreType1 == "stone" && forgeOreType2 == "stone")
        {
            Instantiate(stonePetRock, spawnPosition, Quaternion.identity);
            ClearForge();
            return;
        }
        else if (forgeOreType1 == "tin" && forgeOreType2 == "tin")
        {
            Instantiate(tinPetRock, spawnPosition, Quaternion.identity);
            ClearForge();
            return;
        }
        else if (forgeOreType1 == "copper" && forgeOreType2 == "copper")
        {
            Instantiate(copperPetRock, spawnPosition, Quaternion.identity);
            ClearForge();
            return;
        }
        else if (forgeOreType1 == "tin" && forgeOreType2 == "copper" || forgeOreType1 == "copper" && forgeOreType2 == "tin")
        {
            Instantiate(bronzePetRock, spawnPosition, Quaternion.identity);
            ClearForge();
            return;
        }
        else
        {
            return;
        }

    }
    public void AddToForge(string oreType) // ABSTRACTION
    {
        if (!hud.forgePanel.gameObject.activeSelf)
        {
            return;
        }
        if (!hud.orePanel1.gameObject.activeSelf)
        {
            switch (oreType)
            {
                case "stone":
                    if (GameManager.Instance.stone <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.stone--;
                    hud.orePanel1.sprite = hud.stoneSprite;
                    hud.orePanel1.gameObject.SetActive(true);
                    forgeOreType1 = oreType;
                    break;
                case "tin":
                    if (GameManager.Instance.tin <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.tin--;
                    hud.orePanel1.sprite = hud.tinSprite;
                    hud.orePanel1.gameObject.SetActive(true);
                    forgeOreType1 = oreType;
                    break;
                case "copper":
                    if (GameManager.Instance.copper <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.copper--;
                    hud.orePanel1.sprite = hud.copperSprite;
                    hud.orePanel1.gameObject.SetActive(true);
                    forgeOreType1 = oreType;
                    break;
            }
        }
        else if (!hud.orePanel2.gameObject.activeSelf)
        {
            switch (oreType)
            {
                case "stone":
                    if (GameManager.Instance.stone <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.stone--;
                    hud.orePanel2.sprite = hud.stoneSprite;
                    hud.orePanel2.gameObject.SetActive(true);
                    forgeOreType2 = oreType;
                    break;
                case "tin":
                    if (GameManager.Instance.tin <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.tin--;
                    hud.orePanel2.sprite = hud.tinSprite;
                    hud.orePanel2.gameObject.SetActive(true);
                    forgeOreType2 = oreType;
                    break;
                case "copper":
                    if (GameManager.Instance.copper <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.copper--;
                    hud.orePanel2.sprite = hud.copperSprite;
                    hud.orePanel2.gameObject.SetActive(true);
                    forgeOreType2 = oreType;
                    break;
            }
        }
        hud.UpdateInventory();
    }
    public void RemoveFromForge(Button button) // ABSTRACTION
    {
        string buttonName = button.gameObject.name;

        if (buttonName == "OreImage1")
        {
            string oreType = forgeOreType1;

            switch (oreType)
            {
                case "stone":
                    GameManager.Instance.stone++;
                    hud.orePanel1.sprite = null;
                    hud.orePanel1.gameObject.SetActive(false);
                    forgeOreType1 = null;
                    break;
                case "tin":
                    GameManager.Instance.tin++;
                    hud.orePanel1.sprite = null;
                    hud.orePanel1.gameObject.SetActive(false);
                    forgeOreType1 = null;
                    break;
                case "copper":
                    GameManager.Instance.copper++;
                    hud.orePanel1.sprite = null;
                    hud.orePanel1.gameObject.SetActive(false);
                    forgeOreType1 = null;
                    break;
            }
        }
        else if (buttonName == "OreImage2")
        {
            string oreType = forgeOreType2;

            switch (oreType)
            {
                case "stone":
                    GameManager.Instance.stone++;
                    hud.orePanel2.sprite = null;
                    hud.orePanel2.gameObject.SetActive(false);
                    forgeOreType2 = null;
                    break;
                case "tin":
                    GameManager.Instance.tin++;
                    hud.orePanel2.sprite = null;
                    hud.orePanel2.gameObject.SetActive(false);
                    forgeOreType2 = null;
                    break;
                case "copper":
                    GameManager.Instance.copper++;
                    hud.orePanel2.sprite = null;
                    hud.orePanel2.gameObject.SetActive(false);
                    forgeOreType2 = null;
                    break;
            }
        }
        hud.UpdateInventory();
    }

    public void ClearForge() // ABSTRACTION
    {
        hud.orePanel1.sprite = null;
        hud.orePanel1.gameObject.SetActive(false);
        hud.orePanel2.sprite = null;
        hud.orePanel2.gameObject.SetActive(false);
        forgeOreType1 = null;
        forgeOreType2 = null;
    }
}
