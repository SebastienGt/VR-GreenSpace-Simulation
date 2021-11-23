using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Seed : InteractableObject
{
    private readonly string PLANT_SEED_INSTRUCTIONS = "Great! Now look to your right.";
    private readonly string PLANT_VASE_INSTRUCTIONS = "Look at the vase for three seconds\n to plant the seed.";
    public TextMeshPro SeedInstructionsText;
    public TextMeshPro VaseInstructionsText;
    private bool TextChanged = false;

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (!Player.player.hasSeed) {
            Player.player.getSeed();
            AudioManager.Instance.Play("seed");
            //gameObject.SetActive(false);
            if (!TextChanged) {
                SeedInstructionsText.GetComponent<TextMeshPro>().text = PLANT_SEED_INSTRUCTIONS;
                VaseInstructionsText.GetComponent<TextMeshPro>().text = PLANT_VASE_INSTRUCTIONS;
                TextChanged = true;
            }
        }

    }
}
