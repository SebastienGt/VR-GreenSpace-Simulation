using System.Collections;
using UnityEngine;
using TMPro;

public class Plant : InteractableObject
{
    private readonly string SELL_VASE_INSTRUCTIONS = "Great! Now click on\n the plant to sell it.";
    private readonly string REPEAT_INSTRUCTIONS = "Now you can grow and\n sell more plants!";
    public bool seedPlaced = false; // 0 = not growing, 1 = growing
    private const float growthRate = 0.1f;
    public Spot spot = null;

    public void Start()
    {
        _interactable = false;
        seedPlaced = true;
    }
    public void Update()
    {
        if (transform.localScale.x < 3.0f) {
            var scaleChangeCoord = growthRate * Time.deltaTime;
            var scaleChange = new Vector3(scaleChangeCoord, scaleChangeCoord, scaleChangeCoord);
            transform.localScale += scaleChange;
        }
        else
        {
            if (_interactable == false) {
                _interactable = true;
                GameObject.Find("SpotText").GetComponent<TextMeshPro>().text = SELL_VASE_INSTRUCTIONS;
            }
        }
    }

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        Player.player.ChangeMoney(50);
        gameObject.SetActive(false);
        spot.hasPlant = false;
        if (GameObject.Find("SpotText").GetComponent<TextMeshPro>().text == REPEAT_INSTRUCTIONS) {
            Destroy(GameObject.Find("SpotText"));
        } else {
            GameObject.Find("SpotText").GetComponent<TextMeshPro>().text = REPEAT_INSTRUCTIONS;
        }
        Destroy(GameObject.Find("SeedText"));
    }
}
