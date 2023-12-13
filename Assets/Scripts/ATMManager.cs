using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMManager : MonoBehaviour
{
    public static ATMManager instance;

    public Text cashText; // UI 텍스트 필드: 현금 잔액
    public Text bankText; // UI 텍스트 필드: 은행 잔액
    public InputField depositInput; // UI 인풋 필드: 입금할 금액
    public InputField withdrawInput;
    public GameObject notEnoughPopup; // 부족한 잔액 팝업

    private int cashBalance = 100000; // 현금 잔액 초기값
    private int bankBalance = 50000; // 은행 잔액 초기값

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        cashText.text = "현금\n" + cashBalance.ToString("N0");
        bankText.text = "Balance    " + bankBalance.ToString("N0").PadLeft(8);
    }
    private void Deposit(int amount)
    {
        if (cashBalance < amount)
        {
            notEnoughPopup.SetActive(true);
        }
        else
        {
            cashBalance -= amount;
            bankBalance += amount;

            UpdateUI();
        }
        depositInput.text = "";
    }
    public void DepositAmountClicked(int amount) // 정해진 금액 입금 버튼
    {
        Deposit(amount);
    }
    
    public void DepositInputClicked() // 직접 입력 입금 버튼
    {
        int depositAmount = int.Parse(depositInput.text);
        Deposit(depositAmount);
    }

    private void Withdraw(int amount)
    {
        if (bankBalance < amount)
        {
            notEnoughPopup.SetActive(true);
        }
        else
        {
            bankBalance -= amount;
            cashBalance += amount;

            UpdateUI();
        }
        withdrawInput.text = "";
    }

    public void WithdrawAmountClicked(int amount) // 정해진 금액 출금 버튼
    {
        Withdraw(amount);
    }

    public void WithdrawInputClicked() // 직접 입력 출금 버튼
    {
        int withdrawAmount = int.Parse(withdrawInput.text);
        Withdraw(withdrawAmount);
    }
}
