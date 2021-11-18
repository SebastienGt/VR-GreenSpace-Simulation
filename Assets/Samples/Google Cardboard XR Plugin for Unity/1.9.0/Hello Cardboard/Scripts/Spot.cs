using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public GameObject Plant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerClick()
    {
        if (Player.player.hasSeed) {
            GameObject j = Instantiate(Plant, this.transform);
            Player.player.hasSeed = false;
            j.GetComponent<Plant>().seedPlaced = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
