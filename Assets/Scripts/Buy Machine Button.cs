using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyMachineButton : MonoBehaviour
{
    public CPSMachineManager machine; // Grab the GameObject from the scene
    Button button;
    public TextMeshProUGUI buyText;
    public TextMeshProUGUI ownedText;
    public TextMeshProUGUI costText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(machine.BuyMachine);
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = machine.canAfford;
        buyText.text = "Buy " + machine.machineName;
        ownedText.text = "Owned: " + FormatValue(machine.machinesOwned);
        costText.text = "Cost: " + FormatValue(machine.currentCost) + " Craigs";
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
