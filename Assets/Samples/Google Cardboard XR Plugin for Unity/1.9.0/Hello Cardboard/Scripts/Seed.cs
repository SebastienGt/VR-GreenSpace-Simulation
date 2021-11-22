using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : InteractableObject
{
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (!Player.player.hasSeed) {
            Player.player.getSeed();
            //gameObject.SetActive(false);
        }
    }
}
