using System.Collections;
using UnityEngine;

public class TeleportationMarker : InteractableObject
{
    public TextMesh TeleportationInstructionsMarker;
    public override bool RequiresCloseDistance() {
        return false;
    }
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        Destroy(TeleportationInstructionsMarker);
        if (Player.player.InstantTeleport) {
            Player.player.transform.position = new Vector3(transform.position.x, Player.player.transform.position.y, transform.position.z);
        } else {
            Player.player.DestObject = this;
            Player.player.IsMoving = true;
        }
    }

}
