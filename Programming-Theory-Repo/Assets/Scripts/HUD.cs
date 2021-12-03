using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TMP_Text stone, tin, copper, money, playerName;

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
}
