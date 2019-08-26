using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-9f, 9f), 5, 0);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -5) {
            Start();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Laser") {
            Destroy(other.gameObject);
        }
        if(other.tag == "Player") {
            var player = other.transform.GetComponent<Player>();
            if( player != null) {
                player.Damage();
            }
        }
        Destroy(gameObject);
    }
}
