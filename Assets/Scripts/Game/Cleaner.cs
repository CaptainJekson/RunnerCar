using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [SerializeField] [Range(0, 200)] private float _distanceDestroy;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_player != null)
            DestroyUnit();
    }

    private void DestroyUnit()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) > _distanceDestroy)
            Destroy(gameObject);
    }
}
