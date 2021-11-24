using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{

    public static Player player;
    public bool hasSeed { get; set; }
    public int Money = 0;
    public GameObject seedUI;
    void Start()
    {
        player = this;
        ChangeMoney(20);
    }
    
    public void getSeed()
    {
        hasSeed = true;
        seedUI.SetActive(true);
        ChangeMoney(-5);
    }
    public void PlantSeed()
    {
        hasSeed = false;
        seedUI.SetActive(false);
    }

    public void ChangeMoney(int amount)
    {
        Money += amount;
        UIElement.uIElement.AfficherMoney(Money);
    }
}
