using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    string FormatValue(float value)
    {
        if (value < 1000000f)
        {
            return Mathf.FloorToInt(value).ToString();
        }
        else
        {
            return value.ToString("0.00e0");
        }
    }
}
