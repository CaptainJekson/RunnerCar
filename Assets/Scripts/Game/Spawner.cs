using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _units;
    [SerializeField] private Player _player;

    [SerializeField] [Range(0, 100)] private float _distanceMin;
    [SerializeField] [Range(0, 100)] private float _distanceMax;
    [SerializeField] [Range(0, 200)] private float _initDistance;
    [SerializeField] private bool _isInitDistance;

    private Vector3 _startPosition;
    private float _spawnPosition;

    private void Awake()
    {
        _startPosition = _player.transform.position;

        if (_isInitDistance)
            _spawnPosition = Random.Range(_initDistance + _distanceMin, _initDistance + _distanceMax);
        else
            _spawnPosition = Random.Range(_distanceMin, _distanceMax);
    }

    private void Update()
    {
        if (_player.IsMoving)
            GenerateUnit();
    }

    private void GenerateUnit()
    {
        float distanceSpawn = transform.position.z - _startPosition.z;

        if (distanceSpawn > _spawnPosition)
        {
            Transform unit = _units[Random.Range(0, _units.Count)];
            Instantiate(unit, transform.position, Quaternion.identity);
            _spawnPosition += Random.Range(_distanceMin, _distanceMax);
        }
    }
}
