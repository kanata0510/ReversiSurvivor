using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money
{
    private int _value;
    private const int MinValue = -10000000;
    private const int MaxValue = 0;
    private Money(int value)
    {
        if (!IsValid(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        _value = value;
    }

    public static Money GetInitInstance()
    {
        return new Money(MinValue);
    }

    public bool IsValid(int value)
    {
        return MinValue <= value && value <= MaxValue;
    }

    public Money Add(int value)
    {
        if (value < 0)
        {
            Debug.LogWarning(value);
        }
        return new Money(_value + value);
    }
    
    public Money Sub(int value)
    {
        if (value < 0)
        {
            Debug.LogWarning(value);
        }
        return new Money(_value - value);
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}
