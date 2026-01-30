using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyMachineUpgradeButton : MonoBehaviour
{
    // THIS BUTTON SHOULD BE USED TO UPGRADE A SINGLE MACHINE

    [Tooltip("The upgrade manager this button ties to.")]
    public UniversalMachineUpgradeManager upgrade; // Grab the GameObject from the scene
    CurrencyManager c;

    Button button;
    public TextMeshProUGUI buyText;
    public TextMeshProUGUI costText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GameObject.Find("Currency Manager").GetComponent<CurrencyManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(upgrade.BuyUpgrade);
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = upgrade.canAfford && upgrade.machines[0].machinesOwned >= 1;
        UpdateText();
    }

    void UpdateText()
    {
        buyText.text = "Upgrade " + upgrade.machines[0].machineName; // Later change this to "Buy " + upgrade.upgradeNames[0]
        costText.text = "Cost: " + c.FormatValue(upgrade.currentCost) + " Craigs";
    }
}
