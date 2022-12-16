using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Use transform whenever you want to get information about position, rotation, and scale
    public Transform target;

    // How fast the camera locks on to the target
    public float smoothSpeed = 0.125f;

    /// <summary>
    /// Exact same thing as Update method, but called later. Wait for the target to already
    /// make its movement in its Update method before moving the camera.
    /// </summary>
    void LateUpdate()
    {
        transform.position = target.position;
    }
}
