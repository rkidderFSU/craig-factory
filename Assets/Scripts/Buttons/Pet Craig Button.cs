using UnityEngine;
using UnityEngine.UI;

public class PetCraigButton : MonoBehaviour
{
    CurrencyManager c;
    Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GameObject.Find("Currency Manager").GetComponent<CurrencyManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(PetCraig);
    }

    public void PetCraig()
    {
        c.ProduceCraigInstant();
    }
}
