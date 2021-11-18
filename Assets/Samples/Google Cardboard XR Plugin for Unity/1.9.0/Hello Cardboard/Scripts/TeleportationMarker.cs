using System.Collections;
using UnityEngine;

public class TeleportationMarker : InteractableObject
{
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        Player.player.transform.position = new Vector3(transform.position.x, Player.player.transform.position.y, transform.position.z);
    }

}
