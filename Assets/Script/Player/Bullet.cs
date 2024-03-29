using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f;
    private float _topBound = 22f;
    private float _rightBound = 22f;
    private Vector3 _direction;
    public int damage = 1;

 
    void Update()
    {
        var clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.Translate(_direction * (speed * Time.deltaTime));
        Destroy();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.transform.GetComponent<Enemy>().SetHealth(damage);
            Destroy(gameObject);

        }
    }

    void Destroy()
    {
        if (transform.position.y > _topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -_topBound)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > _rightBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -_rightBound)
        {
            Destroy(gameObject);
        }
    }
}