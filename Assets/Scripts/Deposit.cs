using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deposit : MonoBehaviour
{ 
    int depositAmount;

    void Start()
    {
        string buttonText = GetComponentInChildren<Text>().text;
        depositAmount = int.Parse(buttonText.Replace(",", ""));
    }

    public void Click()
    {
        ATMManager.instance.DepositAmountClicked(depositAmount);
    }
}
