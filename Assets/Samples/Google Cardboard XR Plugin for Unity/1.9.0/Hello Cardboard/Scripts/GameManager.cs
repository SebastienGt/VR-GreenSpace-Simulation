using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float growthSpeed_Plant = 0.1f;
    public TMPro.TextMeshPro growthText;

    public void Awake()
    {
        Instance = this;
    }

    public void ChangeGrowthSpeed(float amount)
    {
        growthSpeed_Plant += amount;
        growthText.text = "" + growthSpeed_Plant;
    }
}
