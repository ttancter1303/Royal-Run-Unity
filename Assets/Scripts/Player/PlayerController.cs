using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float xClamp = 3.5f;
    [SerializeField] float zClamp = 2f;


    Rigidbody rigidbody;
    Vector2 movement;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        
    }
    void HandleMovement()
    {

        Vector3 currentPosition = rigidbody.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition = currentPosition + moveDirection * moveSpeed * Time.deltaTime ;

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);
        rigidbody.MovePosition(newPosition);
    }
}
