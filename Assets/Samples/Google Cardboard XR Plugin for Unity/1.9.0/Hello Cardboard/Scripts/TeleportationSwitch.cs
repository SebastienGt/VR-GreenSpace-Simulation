using System.Collections;
using UnityEngine;
using TMPro;

public class TeleportationSwitch : InteractableObject
{
    public override bool RequiresCloseDistance() {
        return true;
    }
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        if (Player.player.InstantTeleport) {
            Player.player.InstantTeleport = false;
            this.GetComponent<TextMeshPro>().text = "Instant teleport is off";
        } else {
             Player.player.InstantTeleport = true;
            this.GetComponent<TextMeshPro>().text = "Instant teleport is on";
        }
    }

}
