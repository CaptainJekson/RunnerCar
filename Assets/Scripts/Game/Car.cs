using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] [Range(0, 50)] protected float _speed;

    protected virtual void MoveForward(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, speed * Time.deltaTime);
    }
}
