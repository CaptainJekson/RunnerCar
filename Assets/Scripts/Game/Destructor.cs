using UnityEngine;

public class Destructor : MonoBehaviour
{
    [SerializeField] [Range(0, 200)] private float _destructionDistance;

    private PlayerCar _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerCar>();
    }

    private void Update()
    {
        if (_player != null)
            Destroy();
    }

    private void Destroy()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) > _destructionDistance)
            Destroy(gameObject);
    }
}
