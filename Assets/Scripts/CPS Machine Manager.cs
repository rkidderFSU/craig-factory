using UnityEngine;

public class CPSMachineManager : MonoBehaviour
{
    CurrencyManager c;

    [Header("Identity")]
    public string machineName;

    [Header("State")]
    public int machinesOwned = 0;

    [Header("Production")]
    public int craigsPerSecondPerMachine = 1;

    [Header("Cost")]
    public float baseCost = 10f;
    public float costMultiplier = 1.1f;

    public float currentCost;
    public bool canAfford;


    private void Start()
    {
        c = GameObject.Find("Currency Manager").GetComponent<CurrencyManager>();
        currentCost = baseCost;
    }

    private void Update()
    {
        canAfford = c.currentCraigsInternal >= currentCost;
    }

    public void BuyMachine()
    {
        if (canAfford)
        {
            c.currentCraigsInternal -= currentCost;
            machinesOwned++;
            c.craigsPerSecond += craigsPerSecondPerMachine;
            currentCost = Mathf.FloorToInt(baseCost * Mathf.Pow(costMultiplier, machinesOwned));
        }
        else
        {
            return;
        }
    }
}