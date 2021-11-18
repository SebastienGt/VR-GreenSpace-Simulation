using System.Collections;
using UnityEngine;

public class Plant : InteractableObject
{
    public bool seedPlaced = false; // 0 = not growing, 1 = growing
    private const float growthRate = 0.1f;
    public Spot spot = null;

    private void Start()
    {
        _interactable = false;
    }
    public void Update()
    {
        if (seedPlaced && transform.localScale.x < 1) {
            var scaleChangeCoord = growthRate * Time.deltaTime;
            var scaleChange = new Vector3(scaleChangeCoord, scaleChangeCoord, scaleChangeCoord);
            transform.localScale += scaleChange;
        }
        else
        {
            if (_interactable == false)
                _interactable = true;
        }
    }

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        Player.player.Money += 50;
        gameObject.SetActive(false);
        spot.hasPlant = true;
    }
}