using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{

    public void OnPointerClick()
    {
        if (!Player.player.hasSeed) {
            Player.player.hasSeed = true;
            gameObject.SetActive(false);
        }
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
