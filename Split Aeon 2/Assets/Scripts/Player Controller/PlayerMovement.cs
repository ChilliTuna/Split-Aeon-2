using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float forwardMovementSpeed = 5f;
    public float backwardMovementSpeed = 4f;
    public float strafeMovementSpeed = 3f;

    public float verticalLookSensitivity = 1f;
    public float horizontalLookSensitivity = 1f;

    [HideInInspector]
    public bool shouldMove = true;
    [HideInInspector]
    public bool shouldLook = true;

    private Transform playerTransform;
    private Transform cameraTransform;
    private CharacterController playerCharacterController;

    private bool isMoving = false;
    private bool isLooking = false;
    private Vector3 moveVec = new Vector3(0, 0, 0);
    private Vector3 lookVec = new Vector3(0, 0, 0);

    private void Start()
    {
        playerTransform = transform;
        cameraTransform = transform.Find("Player Camera");
        playerCharacterController = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (shouldMove && isMoving)
        {
            Move();
        }
        if (shouldLook && isLooking)
        {
            Look();
        }
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 value = inputValue.Get<Vector2>();
        if (shouldMove || value != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        SetMove(value);
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 value = inputValue.Get<Vector2>();
        if (shouldLook || value != Vector2.zero)
        {
            isLooking = true;
        }
        else
        {
            isLooking = false;
        }
        SetLook(value);
    }

    private void SetMove(Vector2 direction)
    {
        Vector3 moveAmount = direction;
        if (direction != Vector2.zero)
        {
            float moveZ = direction.y > 0 ? direction.y * forwardMovementSpeed : direction.y * backwardMovementSpeed;
            float moveX = direction.x * strafeMovementSpeed;

            moveAmount = new Vector3(transform.right.x * moveX - transform.right.z * moveZ, 0, transform.forward.z * moveZ - transform.forward.x * moveX);
        }
        moveVec = moveAmount;
    }

    private void SetLook(Vector2 direction)
    {
        lookVec.x = direction.x * horizontalLookSensitivity;
        lookVec.y = -direction.y * verticalLookSensitivity;
    }

    private void Move()
    {
        playerCharacterController.Move(moveVec * Time.deltaTime);
    }

    private void Look()
    {
        transform.Rotate(transform.up, lookVec.x, Space.World);
        cameraTransform.Rotate(cameraTransform.right, lookVec.y, Space.World);
    }
}