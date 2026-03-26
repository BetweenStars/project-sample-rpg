using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float xClampRange = 5f;

    private float horizontalInput;

    public void OnMove(InputValue value)
    {
        horizontalInput = value.Get<Vector2>().x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float newX = transform.position.x + (horizontalInput * moveSpeed * Time.fixedDeltaTime);

        newX = Mathf.Clamp(newX, -xClampRange, xClampRange);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
