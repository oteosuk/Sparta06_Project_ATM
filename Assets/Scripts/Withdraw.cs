using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Withdraw : MonoBehaviour
{
    int withdrawAmount;

    void Start()
    {
        string buttonText = GetComponentInChildren<Text>().text;
        withdrawAmount = int.Parse(buttonText.Replace(",", ""));
    }

    public void Click()
    {
        ATMManager.instance.WithdrawAmountClicked(withdrawAmount);
    }
}
