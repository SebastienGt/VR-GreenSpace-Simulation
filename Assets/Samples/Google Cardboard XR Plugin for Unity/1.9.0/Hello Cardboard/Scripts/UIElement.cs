using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    public static UIElement uIElement;

    public TMPro.TextMeshProUGUI textMoney;
    public TMPro.TextMeshProUGUI textWarning;

    public string GetWarningText()
    {
        return textWarning.text;
    }

    public void Warn(string warning)
    {
        textWarning.text = "" + warning;
    }

    private void Awake()
    {
        uIElement = this;
    }

    public void AfficherMoney(int money)
    {
        textMoney.text = "" + money;
    }
}
