using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;  // CameraPivot sur le joueur
    [SerializeField] private Vector3 offset = new Vector3(0, 2f, -4f);
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    void LateUpdate()
    {
        if (target == null) return;

        // Position : suit le joueur avec offset relatif à sa rotation
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Rotation : s'aligne avec la direction du joueur
        Quaternion targetRotation = Quaternion.LookRotation(target.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
