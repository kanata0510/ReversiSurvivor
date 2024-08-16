using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private List<MoveInput> moveInputs;

    [SerializeField] private float moveRate = 1f;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        foreach (var moveInput in moveInputs)
        {
            moveInput.MoveObservable
                .Subscribe(Move)
                .AddTo(this);
            moveInput.MoveCancelObservable
                .Subscribe(_ => Stop())
                .AddTo(this);
        }
    }

    private void Move(Vector2 direction)
    {
        Debug.Log(direction);
        _rb.velocity = direction * moveRate;
    }
    
    private void Stop()
    {
        _rb.velocity = Vector3.zero;
    }
}
