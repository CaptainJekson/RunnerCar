using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] [Range(0, 500)] private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();

        if (player)
        {
            player.AddScore(1);
            Destroy(gameObject);
        }
    }
}
