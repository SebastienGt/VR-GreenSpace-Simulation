using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : InteractableObject
{
    private readonly string PLANT_SEED_INSTRUCTIONS = "Great! Now look to your right.";
    private readonly string PLANT_VASE_INSTRUCTIONS = "Look at the vase for three seconds to plant the seed.";
    public TextMesh SeedInstructionsText;
    public TextMesh VaseInstructionsText;
    private bool TextChanged = false;

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (!Player.player.hasSeed) {
            Player.player.hasSeed = true;
            Player.player.Money -= 5;
            //gameObject.SetActive(false);
            if (!TextChanged) {
                SeedInstructionsText.GetComponent<TextMesh>().text = PLANT_SEED_INSTRUCTIONS;
                VaseInstructionsText.GetComponent<TextMesh>().text = PLANT_VASE_INSTRUCTIONS;
                TextChanged = true;
            }
        }

    }
}
