using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed = 9.0f;

    public float LifeTime = 15.0f;

    public GameObject hitEffect;

    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }


    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Time.deltaTime * BulletSpeed * Vector3.left, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
