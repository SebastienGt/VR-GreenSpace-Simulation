using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMachine : InteractableObject
{
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (Player.player.hasPlant)
        {
            Player.player.sellPlant();
        }
    }
}
