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
        if (Player.player.hasSeed && !hasPlant)
        {
            _interactable = true;
        }
        else
        {
            _interactable = false;
        }

        if (_interactable && Player.player.hasSeed && !hasPlant)
            SetMaterial(true);
    }
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (Player.player.hasSeed) {
            GameObject g = Instantiate(Plant, this.transform);
            Player.player.hasSeed = false;
            g.GetComponent<Plant>().seedPlaced = true;
            g.GetComponent<Plant>().spot = this;
            hasPlant = true;
        }
    }
}
