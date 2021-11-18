using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player player;
    public bool hasSeed { get; set; }
    public int Money;
    public GameObject seedUI;
    void Awake()
    {
        player = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
