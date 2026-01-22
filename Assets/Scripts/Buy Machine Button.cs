using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyMachineButton : MonoBehaviour
{
    public CPSMachineManager machine; // Grab the GameObject from the scene
    Button button;
    public TextMeshProUGUI buyText;
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
        costText.text = "Cost: " + machine.currentCost + " Craigs";
    }
}
