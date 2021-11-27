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
            var pos = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, this.transform.position.z);
            GameObject g = Instantiate(Plant, pos, new Quaternion(0, 0, 0, 0));
            g.GetComponent<Plant>().spot = this;
            VaseInstructionsText.GetComponent<TextMeshPro>().text = GROW_VASE_INSTRUCTIONS;
            Player.player.PlantSeed();
            hasPlant = true;
            AudioManager.Instance.Play("plant");
        }
    }
}
