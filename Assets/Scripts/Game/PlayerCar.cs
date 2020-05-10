using UnityEngine;
using UnityEngine.Events;

public class PlayerCar : Car
{
    [SerializeField] [Range(0, 20)] private float _sideSpeed;

    [SerializeField] private Transform _rightLinePosition;
    [SerializeField] private Transform _middleLinePosition;
    [SerializeField] private Transform _leftLinePosition;

    private Vector3 _targetLinePosition;

    public event UnityAction PointAdded;
    public event UnityAction PlayerLoad;
    public event UnityAction PlayerDied;

    public bool IsMoving { get; private set; }
    public int Score { get; private set; }

    private void Start()
    {
        PlayerLoad?.Invoke();
        _targetLinePosition = _middleLinePosition.position;
        IsMoving = false;
    }

    private void Update()
    {
        ChangeLine(KeyCode.D, _rightLinePosition.position, _leftLinePosition.position);
        ChangeLine(KeyCode.A, _leftLinePosition.position, _rightLinePosition.position);

        StartMove(KeyCode.Space);
    }

    public void Die()
    {
        PlayerDied?.Invoke();
        Destroy(gameObject);
    }

    public void AddScore(int count)
    {
        Score += count;
        PointAdded?.Invoke();
    }

    private void ChangeLine(KeyCode keyCode, Vector3 forward, Vector3 backward)
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (_middleLinePosition.position.x == transform.position.x)
                _targetLinePosition = forward;
            if (backward.x == transform.position.x)
                _targetLinePosition = _middleLinePosition.position;
        }
    }

    private void StartMove(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
            IsMoving = true;

        if (IsMoving)
        {
            MoveForward(_speed);
            MoveSide(_sideSpeed, _targetLinePosition);
        }
    }

    private void MoveSide(float speed, Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }
}
