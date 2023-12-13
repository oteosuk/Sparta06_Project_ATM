using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMManager : MonoBehaviour
{
    public static ATMManager instance;

    public Text cashText; // UI �ؽ�Ʈ �ʵ�: ���� �ܾ�
    public Text bankText; // UI �ؽ�Ʈ �ʵ�: ���� �ܾ�
    public InputField depositInput; // UI ��ǲ �ʵ�: �Ա��� �ݾ�
    public InputField withdrawInput;
    public GameObject notEnoughPopup; // ������ �ܾ� �˾�
    public string buttontext;

    private int cashBalance = 100000; // ���� �ܾ� �ʱⰪ
    private int bankBalance = 50000; // ���� �ܾ� �ʱⰪ

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI(); // UI ������Ʈ �Լ� ȣ��
        notEnoughPopup.SetActive(false); // ������ �ܾ� �˾� ��Ȱ��ȭ
    }

    void UpdateUI()
    {
        cashText.text = "����\n" + cashBalance.ToString("N0");
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
    public void DepositAmountClicked(int amount) // ������ �ݾ� �Ա� ��ư
    {
        Deposit(amount);
    }
    
    public void DepositInputClicked() // ���� �Է� �Ա� ��ư
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

    public void WithdrawAmountClicked(int amount) // ������ �ݾ� ��� ��ư
    {
        Withdraw(amount);
    }

    public void WithdrawInputClicked() // ���� �Է� ��� ��ư
    {
        int withdrawAmount = int.Parse(withdrawInput.text);
        Withdraw(withdrawAmount);
    }

    


}
