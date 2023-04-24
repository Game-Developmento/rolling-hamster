using UnityEngine;

/**
 * This component follows the position of a given object, but not its rotation.
 * Especially useful for cameras.
 */
public class PositionFollower : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow = null;

    // NOTE: FixedUpdate should be used for all updates related to rigid bodies or the physics engine.
    private void FixedUpdate()
    {
        Vector3 new_position = transform.position;
        new_position.x = objectToFollow.transform.position.x;
        new_position.y = objectToFollow.transform.position.y;
        transform.position = new_position;
    }
}
