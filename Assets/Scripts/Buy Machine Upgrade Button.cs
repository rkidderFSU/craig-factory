using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyMachineUpgradeButton : MonoBehaviour
{
    [Tooltip("The upgrade manager this button ties to.")]
    public CPSMachineUpgradeManager upgrade; // Grab the GameObject from the scene
    Button button;
    public TextMeshProUGUI buyText;
    public TextMeshProUGUI costText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(upgrade.BuyUpgrade);
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = upgrade.canAfford;
        buyText.text = "Upgrade " + upgrade.machine.machineName; // Later set this to "Buy " + upgrade.upgradeNames[0]
        costText.text = "Cost: " + FormatValue(upgrade.currentCost) + " Craigs";
    }

    string FormatValue(double value)
    {
        // Rounds to nearest integer when below one million, otherwise format in scientific notation to 2 decimal places
        if (value < 1000f)
        {
            return Math.Floor(value).ToString();
        }
        else if (value < 10000f)
        {
            return Math.Floor(value).ToString("0,000");
        }
        else if (value < 100000f)
        {
            return Math.Floor(value).ToString("00,000");
        }
        else if (value < 1000000f)
        {
            return Math.Floor(value).ToString("000,000");
        }
        else
        {
            return value.ToString("0.00e0");
        }
    }
}
