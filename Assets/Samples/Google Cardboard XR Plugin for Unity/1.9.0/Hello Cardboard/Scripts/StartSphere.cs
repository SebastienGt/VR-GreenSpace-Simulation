using System.Collections;
using UnityEngine;

public class StartSphere : InteractableObject
{
    public InteractableObject TargetMarker;

    public override bool RequiresCloseDistance() {
        return true;
    }
    public override void OnPointerClick()
    {
        base.OnPointerClick();
        Player.player.transform.position = TargetMarker.transform.position + 
        new Vector3(0, 1.6F, 0);
    }

}
