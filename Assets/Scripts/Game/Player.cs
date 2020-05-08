using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] private float _speed;
    [SerializeField] [Range(0, 20)] private float _sideSpeed;

    [SerializeField] private Transform _pointRightLine;
    [SerializeField] private Transform _pointMiddleLine;
    [SerializeField] private Transform _pointLeftLine;

    [SerializeField] private GameObject _gameOverPanel;

    private Vector3 _targetSidePosition;

    public event UnityAction PointAdded;
    public event UnityAction PlayerLoad;
    public event UnityAction<int> PlayerDied;

    public bool IsMoving { get; private set; }
    public int Score { get; private set; }

    private void Start()
    {
        PlayerLoad?.Invoke();
        _targetSidePosition = _pointMiddleLine.position;
        IsMoving = false;
    }

    private void Update()
    {
        ChangeLine(KeyCode.D, _pointRightLine.position, _pointLeftLine.position);
        ChangeLine(KeyCode.A, _pointLeftLine.position, _pointRightLine.position);

        StartMove(KeyCode.Space);
    }

    public void Die()
    {
        _gameOverPanel.SetActive(true);
        PlayerDied?.Invoke(Score);
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
            if (_pointMiddleLine.position.x == transform.position.x)
                _targetSidePosition = forward;
            if (backward.x == transform.position.x)
                _targetSidePosition = _pointMiddleLine.position;
        }
    }

    private void StartMove(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
            IsMoving = true;

        if (IsMoving)
        {
            MoveForward(_speed);
            MoveSide(_sideSpeed, _targetSidePosition);
        }
    }

    private void MoveForward(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, speed * Time.deltaTime);
    }

    private void MoveSide(float speed, Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }
}
