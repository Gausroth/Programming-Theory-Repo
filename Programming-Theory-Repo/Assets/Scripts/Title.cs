using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Title : MonoBehaviour
{
    public void StartGame(TMP_InputField input)
    {
        if (input.text == "")
        {
            return;
        }
        else
        {
            string playerName = input.text;
            GameManager.Instance.PlayerName = playerName;
            SceneManager.LoadScene(1);
        }
    }
}
