using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

public class MoneyModel : MonoBehaviour
{
    public ReadOnlyReactiveProperty<Money> ReactiveMoney => _money;
    private ReactiveProperty<Money> _money = new ReactiveProperty<Money>(Money.GetInitInstance());

    public void AddMoney(int value)
    {
        _money.Value = _money.CurrentValue.Add(value);
    }

    public void SubMoney(int value)
    {
        _money.Value = _money.CurrentValue.Sub(value);
    }
}
