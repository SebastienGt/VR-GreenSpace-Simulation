using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : InteractableObject
{
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (!Player.player.hasSeed) {
            Player.player.hasSeed = true;
            Player.player.Money -= 5;
            //gameObject.SetActive(false);
        }
    }
}
