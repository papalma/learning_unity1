using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private int lives = 4;
    [SerializeField] private float speed = 4.0f;

    private float _canFire = -1.0f;

    void Update()
    {
        CalculateMovement();
        ShootLaser();
    }

    void CalculateMovement()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        float verticalValue = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalValue, verticalValue, 0);
        transform.Translate(direction * speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9, 9),
                Mathf.Clamp(transform.position.y, -4, 4), 0);
    }

    void ShootLaser()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0.0f, 0.8f, 0.0f), Quaternion.identity);
        }
    }

    public void Damage()
    {
        lives -= 1;
        if(lives < 1) {
            Destroy(gameObject);
        }
    }
}
