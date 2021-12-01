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
    public float xVel;
    public float zVel;
    public TeleportationMarker DestObject;
    public bool IsMoving = false;
    public bool InstantTeleport;


    void Start()
    {
        player = this;
        ChangeMoney(20);
        DestObject = null;
        IsMoving = false;
    }

    // Gets called at each timestep
    // To be used for physics simulation
    void FixedUpdate()
    {
        if (DestObject == null || !IsMoving) {
            return;
        }
        float dstDist = (DestObject.transform.position - transform.position).magnitude;
        if (dstDist <= 0.3f) {
            DestObject = null;
            IsMoving = false;
            xVel = 0;
            zVel = 0;
            return;
        }
        
        transform.position = Vector3.Lerp(transform.position, DestObject.transform.position + new Vector3(0, 1.6f, 0), 0.2f);
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
