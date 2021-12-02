using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TMP_Text stone, tin, copper;

    public void UpdateInventory()
    {
        stone.text = GameManager.Instance.Stone.ToString();
        tin.text = GameManager.Instance.Tin.ToString();
        copper.text = GameManager.Instance.Copper.ToString();
    }
}
