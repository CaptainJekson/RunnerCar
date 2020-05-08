using UnityEngine;

public class SpawnerPosition : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distanceToPlayer;

    private void Update()
    {
        if (_player != null)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z + _distanceToPlayer);
            transform.position = position;
        }
    }
}
