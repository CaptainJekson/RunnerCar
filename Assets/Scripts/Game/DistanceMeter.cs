using UnityEngine;

public class DistanceMeter : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _startPosition;
    private float _distance;

    private void Awake()
    {
        _startPosition = _target.position.z;
    }

    public float GetDistance()
    {
        if (_target != null)
            _distance = _target.position.z - _startPosition;

        return _distance;
    }
}
