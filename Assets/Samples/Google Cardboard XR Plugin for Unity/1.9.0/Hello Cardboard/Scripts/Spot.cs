using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : InteractableObject
{
    // If the spot already have a plant.
    public bool hasPlant = false;
    // Prefab
    public GameObject Plant;

    public override void OnPointerEnter()
    {
        //if (_interactable && Player.player.hasSeed && !hasPlant)
        SetMaterial(true);
    }
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (Player.player.hasSeed) {
            GameObject g = Instantiate(Plant, this.transform);
            g.GetComponent<Plant>().spot = this;
            Player.player.PlantSeed();
            hasPlant = true;
        }
    }
}
