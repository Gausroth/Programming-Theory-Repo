using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TMP_Text stone, tin, copper, money, playerName;

    public Image orePanel1;
    public Image orePanel2;

    public Sprite stoneSprite, tinSprite, copperSprite;

    public void UpdateInventory() 
    {
        stone.text = GameManager.Instance.stone.ToString();
        tin.text = GameManager.Instance.tin.ToString();
        copper.text = GameManager.Instance.copper.ToString();
    }

    public void UpdateMoney()
    {
        money.text = GameManager.Instance.money.ToString();
    }

    public void UpdatePlayerName()
    {
        playerName.text = GameManager.Instance.playerName;
    }

    public void AddToForge(string oreType)
    {
        Forge forge = GameObject.Find("Forge").GetComponent<Forge>();
        Debug.Log("Added " + oreType + " to forge");

        if (!orePanel1.gameObject.activeSelf)
        {
            switch (oreType)
            {
                case "stone":
                    if(GameManager.Instance.stone <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.stone--;
                    orePanel1.sprite = stoneSprite;
                    orePanel1.gameObject.SetActive(true);
                    forge.oreType1 = oreType;
                    break;
                case "tin":
                    if (GameManager.Instance.tin <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.tin--;
                    orePanel1.sprite = tinSprite;
                    orePanel1.gameObject.SetActive(true);
                    forge.oreType1 = oreType;
                    break;
                case "copper":
                    if (GameManager.Instance.copper <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.copper--;
                    orePanel1.sprite = copperSprite;
                    orePanel1.gameObject.SetActive(true);
                    forge.oreType1 = oreType;
                    break;
            }
        }
        else if (!orePanel2.gameObject.activeSelf)
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
                    orePanel2.sprite = stoneSprite;
                    orePanel2.gameObject.SetActive(true);
                    forge.oreType2 = oreType;
                    break;
                case "tin":
                    if (GameManager.Instance.tin <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.tin--;
                    orePanel2.sprite = tinSprite;
                    orePanel2.gameObject.SetActive(true);
                    forge.oreType2 = oreType;
                    break;
                case "copper":
                    if (GameManager.Instance.copper <= 0)
                    {
                        Debug.Log("Not Enough Ore");
                        return;
                    }
                    GameManager.Instance.copper--;
                    orePanel2.sprite = copperSprite;
                    orePanel2.gameObject.SetActive(true);
                    forge.oreType2 = oreType;
                    break;
            }
        }
        UpdateInventory();
    }
    public void RemoveFromForge(Button button)
    {
        Forge forge = GameObject.Find("Forge").GetComponent<Forge>();
        Debug.Log("Removed Ore from forge");

        string buttonName = button.gameObject.name;

        if(buttonName == "OreImage1")
        {
            string oreType = forge.oreType1;

            switch (oreType)
            {
                case "stone":
                    GameManager.Instance.stone++;
                    orePanel1.sprite = null;
                    orePanel1.gameObject.SetActive(false);
                    forge.oreType1 = null;
                    break;
                case "tin":
                    GameManager.Instance.tin++;
                    orePanel1.sprite = null;
                    orePanel1.gameObject.SetActive(false);
                    forge.oreType1 = null;
                    break;
                case "copper":
                    GameManager.Instance.copper++;
                    orePanel1.sprite = null;
                    orePanel1.gameObject.SetActive(false);
                    forge.oreType1 = null;
                    break;
            }
        }
        else if (buttonName == "OreImage2")
        {
            string oreType = forge.oreType2;

            switch (oreType)
            {
                case "stone":
                    GameManager.Instance.stone++;
                    orePanel2.sprite = null;
                    orePanel2.gameObject.SetActive(false);
                    forge.oreType2 = null;
                    break;
                case "tin":
                    GameManager.Instance.tin++;
                    orePanel2.sprite = null;
                    orePanel2.gameObject.SetActive(false);
                    forge.oreType2 = null;
                    break;
                case "copper":
                    GameManager.Instance.copper++;
                    orePanel2.sprite = null;
                    orePanel2.gameObject.SetActive(false);
                    forge.oreType2 = null;
                    break;
            }
        }
        UpdateInventory();
    }
}
