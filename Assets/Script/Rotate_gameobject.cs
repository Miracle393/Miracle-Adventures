using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_gameobject : MonoBehaviour
{
    [SerializeField] private float speed = 2f;


    void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
