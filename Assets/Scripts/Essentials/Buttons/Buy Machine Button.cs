using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BuyMachineButton : MonoBehaviour
{
    public CPSMachineManager machine; // Grab the GameObject from the scene
    public GameObject infoDisplay;
    CurrencyManager c;
    Button button;
    public TextMeshProUGUI buyText;
    public TextMeshProUGUI ownedText;
    public TextMeshProUGUI costText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GameObject.Find("Currency Manager").GetComponent<CurrencyManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(machine.BuyMachine);
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = machine.canAfford;
        UpdateText();
    }

    private void OnMouseEnter()
    {
        infoDisplay.SetActive(true);
        Debug.Log("Displaying Info");
    }

    private void OnMouseExit()
    {
        infoDisplay.SetActive(false);
        Debug.Log("No longer displaying Info");
    }

    void UpdateText()
    {
        buyText.text = "Buy " + machine.machineName;
        ownedText.text = "Owned: " + c.FormatValue(machine.machinesOwned);
        costText.text = "Cost: " + c.FormatValue(machine.currentCost) + " Craigs";
    }
}
