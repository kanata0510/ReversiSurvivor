using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.Serialization;

public class TouchPresenter : MonoBehaviour
{
    [SerializeField] private InputActionReference touchActionReference;
    [SerializeField] private VirtualPadMovement padView;
    // Start is called before the first frame update
    void Start()
    {
        InputAction touchInputAction = touchActionReference.action;
        touchInputAction.Enable();
        touchInputAction.started += x =>
        {
            Debug.Log("start");
            padView.OnTouchStarted(x.ReadValue<Vector2>());
        };
        touchInputAction.canceled += _ =>
        {
            Debug.Log("cancel");
            padView.OnReleased();
        };
    }
}
