using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMManager : MonoBehaviour
{
    public Text cashText; // UI �ؽ�Ʈ �ʵ�: ���� �ܾ�
    public Text bankText; // UI �ؽ�Ʈ �ʵ�: ���� �ܾ�
    public InputField depositInput; // UI ��ǲ �ʵ�: �Ա��� �ݾ�
    public InputField withdrawInput;
    public GameObject notEnoughPopup; // ������ �ܾ� �˾�

    private int cashBalance = 100000; // ���� �ܾ� �ʱⰪ
    private int bankBalance = 50000; // ���� �ܾ� �ʱⰪ

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

    // �Ա� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    public void DepositButtonClicked()
    {
        // ��ǲ �ʵ忡�� �Է��� �ݾ��� ������
        int depositAmount = int.Parse(depositInput.text);

        // ������ �Ա��� �ݾ׺��� ������ ������ �ܾ� �˾��� ���
        if (cashBalance < depositAmount)
        {
            notEnoughPopup.SetActive(true);
        }
        else
        {
            // ���ݿ��� �������� �ݾ� ��ü
            cashBalance -= depositAmount;
            bankBalance += depositAmount;

            // UI ������Ʈ
            UpdateUI();
        }
    }

    // �Ա� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    public void WithdrawButtonClicked()
    {
        // ��ǲ �ʵ忡�� �Է��� �ݾ��� ������
        int WithdrawAmount = int.Parse(depositInput.text);

        // ������ �Ա��� �ݾ׺��� ������ ������ �ܾ� �˾��� ���
        if (bankBalance < WithdrawAmount)
        {
            notEnoughPopup.SetActive(true);
        }
        else
        {
            // ���ݿ��� �������� �ݾ� ��ü
            bankBalance -= WithdrawAmount;
            cashBalance += WithdrawAmount;

            // UI ������Ʈ
            UpdateUI();
        }
    }

    /*// ������ �ܾ� �˾� �ݱ� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    public void CloseNotEnoughPopup()
    {
        notEnoughPopup.SetActive(false);
    }*/
}
