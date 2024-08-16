using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Text moneyText;

    public void SetText(Money value)
    {
        moneyText.text = value.ToString();
    }
}
