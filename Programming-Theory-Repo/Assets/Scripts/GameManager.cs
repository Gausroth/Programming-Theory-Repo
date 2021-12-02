using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    int stone, tin, copper;
    public int Stone // ENCAPSULATION
    {
        get { return stone; }
        set { stone = value; }
    }
    public int Tin // ENCAPSULATION
    {
        get { return tin; }
        set { tin = value; }
    }
    public int Copper // ENCAPSULATION
    {
        get { return copper; }
        set { copper = value; }
    }

    string playerName;
    public string PlayerName // ENCAPSULATION
    {
        get { return playerName; }
        set { playerName = value; }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
