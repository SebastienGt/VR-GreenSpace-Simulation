using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowthSlider : InteractableObject
{
    public bool positive;
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (!_interactable)
            return;
        Player.player.DestObject = null;
        Player.player.IsMoving = false;


        if (positive)
        {
            GameManager.Instance.ChangeGrowthSpeed(0.05f);
            Player.player.ChangeMoney(-20);
        }
        else
        {
            GameManager.Instance.ChangeGrowthSpeed(-0.05f);
            Player.player.ChangeMoney(+20);
        }
    }
}
