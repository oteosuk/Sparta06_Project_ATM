using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMManager : MonoBehaviour
{
    public Text cashText; // UI 텍스트 필드: 현금 잔액
    public Text bankText; // UI 텍스트 필드: 은행 잔액
    public InputField depositInput; // UI 인풋 필드: 입금할 금액
    public InputField withdrawInput;
    public GameObject notEnoughPopup; // 부족한 잔액 팝업

    private int cashBalance = 100000; // 현금 잔액 초기값
    private int bankBalance = 50000; // 은행 잔액 초기값

    void Start()
    {
        UpdateUI(); // UI 업데이트 함수 호출
        notEnoughPopup.SetActive(false); // 부족한 잔액 팝업 비활성화
    }

    void UpdateUI()
    {
        cashText.text = "현금\n" + cashBalance.ToString("N0");
        bankText.text = "Balance    " + bankBalance.ToString("N0").PadLeft(8);
    }

    // 입금 버튼 클릭 이벤트 핸들러
    public void DepositButtonClicked()
    {
        // 인풋 필드에서 입력한 금액을 가져옴
        int depositAmount = int.Parse(depositInput.text);

        // 현금이 입금할 금액보다 작으면 부족한 잔액 팝업을 띄움
        if (cashBalance < depositAmount)
        {
            notEnoughPopup.SetActive(true);
        }
        else
        {
            // 현금에서 은행으로 금액 이체
            cashBalance -= depositAmount;
            bankBalance += depositAmount;

            // UI 업데이트
            UpdateUI();
        }
    }

    // 입금 버튼 클릭 이벤트 핸들러
    public void WithdrawButtonClicked()
    {
        // 인풋 필드에서 입력한 금액을 가져옴
        int WithdrawAmount = int.Parse(depositInput.text);

        // 현금이 입금할 금액보다 작으면 부족한 잔액 팝업을 띄움
        if (bankBalance < WithdrawAmount)
        {
            notEnoughPopup.SetActive(true);
        }
        else
        {
            // 현금에서 은행으로 금액 이체
            bankBalance -= WithdrawAmount;
            cashBalance += WithdrawAmount;

            // UI 업데이트
            UpdateUI();
        }
    }

    /*// 부족한 잔액 팝업 닫기 버튼 클릭 이벤트 핸들러
    public void CloseNotEnoughPopup()
    {
        notEnoughPopup.SetActive(false);
    }*/
}
