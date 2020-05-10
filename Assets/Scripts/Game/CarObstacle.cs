using UnityEngine;

public class CarObstacle : Car
{
    private void Update()
    {
        MoveForward(_speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerCar player = collision.gameObject.GetComponent<PlayerCar>();

        if (player)
            player.Die();
    }
}
