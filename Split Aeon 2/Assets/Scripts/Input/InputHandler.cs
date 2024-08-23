using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.actions["Move"].performed += PerformMove;
        playerInput.actions["Look"].performed += PerformLook;
        playerInput.actions["Shoot"].performed += PerformShoot;
    }

    private void OnDisable()
    {
        playerInput.actions["Move"].performed -= PerformMove;
        playerInput.actions["Look"].performed -= PerformLook;
        playerInput.actions["Shoot"].performed -= PerformShoot;
    }
    private void PerformMove(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Moved");
    }

    private void OnMove()
    {
        Debug.Log("Sent Move");
    }

    private void PerformLook(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Looked");
    }
    
    private void PerformShoot(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Shot");
    }

    public void Test()
    {

    }
}