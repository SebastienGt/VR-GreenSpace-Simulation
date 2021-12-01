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
        float xAcc = 0, zAcc = 0;
        if (DestObject == null || !IsMoving) {
            return;
        }
        float dstDist = (DestObject.transform.position - transform.position).magnitude;
        if (dstDist < 0) {
            dstDist = -dstDist;
        }
        Vector3 direction = (DestObject.transform.position - transform.position);
        direction = direction / direction.magnitude;
        xAcc = System.Math.Min(0.004f * dstDist, 0.3f);
        zAcc = System.Math.Min(0.004f * dstDist, 0.3f);
        if (dstDist <= 0.3f) {
            DestObject = null;
            IsMoving = false;
            xVel = 0;
            zVel = 0;
            return;
        }
        xVel = xVel + xAcc;
        zVel = zVel + zAcc;
        Vector3 velVec = new Vector3(direction.x * xVel, 0.0f, direction.z * zVel);
        transform.position += velVec;
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
