using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TMP_Text stone, tin, copper, money, playerName;

    public Image orePanel1, orePanel2;

    public GameObject forgePanel;

    public Sprite stoneSprite, tinSprite, copperSprite;

    public void UpdateInventory() // ABSTRACTION
    {
        stone.text = GameManager.Instance.stone.ToString();
        tin.text = GameManager.Instance.tin.ToString();
        copper.text = GameManager.Instance.copper.ToString();
    }

    public void UpdateMoney() // ABSTRACTION
    {
        money.text = GameManager.Instance.money.ToString();
    }

    public void UpdatePlayerName() // ABSTRACTION
    {
        playerName.text = GameManager.Instance.playerName;
    }   
}
