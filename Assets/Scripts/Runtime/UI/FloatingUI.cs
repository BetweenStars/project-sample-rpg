using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;
    public Vector3 offset = new Vector3(0, 2f, 0);

    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 targetWorldPos = target.position + offset;
        Vector3 screenPos = mainCamera.WorldToScreenPoint(targetWorldPos);
        transform.position = screenPos;
    }
}
