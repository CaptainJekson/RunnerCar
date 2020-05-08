using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        if (_target != null)
            transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z);
    }
}

