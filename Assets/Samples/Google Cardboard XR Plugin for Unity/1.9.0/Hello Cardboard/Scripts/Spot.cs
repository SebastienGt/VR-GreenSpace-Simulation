using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spot : InteractableObject
{
    private readonly string GROW_VASE_INSTRUCTIONS = "Great! Now wait for\n the plant to grow...";
    public TextMeshPro VaseInstructionsText;
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
            VaseInstructionsText.GetComponent<TextMeshPro>().text = GROW_VASE_INSTRUCTIONS;
            Player.player.PlantSeed();
            hasPlant = true;
            AudioManager.Instance.Play("plant");
        }
    }
}
