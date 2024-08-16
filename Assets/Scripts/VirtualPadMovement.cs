using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.Serialization;

public class VirtualPadMovement : MonoBehaviour
{
    [SerializeField] private GameObject padBodyObject;
    
    public void OnTouchStarted(Vector2 position)
    {
        padBodyObject.SetActive(true);
        padBodyObject.GetComponent<RectTransform>().position = position;
    }
    
    public void OnReleased()
    {
        padBodyObject.SetActive(false);
    }
}
