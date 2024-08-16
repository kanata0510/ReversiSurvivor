using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] private MoneyModel moneyModel;
    [SerializeField] private MoneyView moneyView;
    // Start is called before the first frame update
    void Start()
    {
        moneyModel.ReactiveMoney
            .Subscribe(moneyView.SetText)
            .AddTo(this);
    }
}
