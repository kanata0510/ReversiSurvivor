using System;
using System.Collections;
using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveInput : MonoBehaviour
{
    public Observable<Vector2> MoveObservable => _moveSubject;
    private Subject<Vector2> _moveSubject = new Subject<Vector2>();
    public Observable<Unit> MoveCancelObservable => _moveCancelSubject;
    private Subject<Unit> _moveCancelSubject = new Subject<Unit>();
    
    [SerializeField] private InputAction moveAction;

    private void Start()
    {
        moveAction.Enable();
        Observable.FromEvent<InputAction.CallbackContext>(
                x => moveAction.performed += x,
                y => moveAction.performed -= y
            ).Select(x => x.ReadValue<Vector2>())
            .Subscribe(_moveSubject.OnNext)
            .AddTo(this);

        Observable.FromEvent<InputAction.CallbackContext>(
                x => moveAction.canceled += x,
                y => moveAction.canceled -= y
            ).Subscribe(x => _moveCancelSubject.OnNext(Unit.Default))
            .AddTo(this);
    }
}
