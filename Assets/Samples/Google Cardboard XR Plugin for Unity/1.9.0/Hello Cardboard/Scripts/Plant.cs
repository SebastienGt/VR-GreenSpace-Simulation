using System.Collections;
using UnityEngine;

public class Plant : InteractableObject
{
    private readonly string SELL_VASE_INSTRUCTIONS = "Great! Now click on the plant to sell it.";
    private readonly string REPEAT_INSTRUCTIONS = "Now you can grow and sell more plants!";
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
            var scaleChange = new Vector3(scaleChangeCoord, scaleChangeCoord * 2, scaleChangeCoord);
            transform.localScale += scaleChange;
        }
        else
        {
            if (_interactable == false) {
                _interactable = true;
                GameObject.Find("InstructionsVase").GetComponent<TextMesh>().text = SELL_VASE_INSTRUCTIONS;
            }
        }
    }

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        Player.player.Money += 50;
        gameObject.SetActive(false);
        Player.player.hasSeed = false;
        spot.hasPlant = false;
        if (GameObject.Find("InstructionsVase").GetComponent<TextMesh>().text == REPEAT_INSTRUCTIONS) {
            Destroy(GameObject.Find("InstructionsVase"));
        } else {
            GameObject.Find("InstructionsVase").GetComponent<TextMesh>().text = REPEAT_INSTRUCTIONS;
        }
        Destroy(GameObject.Find("InstructionsSeed"));
    }
}
