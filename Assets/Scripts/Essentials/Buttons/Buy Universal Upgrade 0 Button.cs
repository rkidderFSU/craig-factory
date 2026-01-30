using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyUniversalUpgradeZeroButton : MonoBehaviour
{
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
        button.interactable = upgrade.canAfford;
        buyText.text = "Increase all Craig production by x" + upgrade.craigMultiplierPerUpgrade;
        costText.text = "Cost: " + c.FormatValue(upgrade.currentCost) + " Craigs";
    }
}
