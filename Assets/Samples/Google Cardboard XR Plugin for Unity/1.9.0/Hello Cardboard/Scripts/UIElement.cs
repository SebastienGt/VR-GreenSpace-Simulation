using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    public static UIElement uIElement;

    public TMPro.TextMeshProUGUI textMoney;

    private void Awake()
    {
        uIElement = this;
    }

    public void AfficherMoney(int money)
    {
        textMoney.text = "" + money;
    }
}
