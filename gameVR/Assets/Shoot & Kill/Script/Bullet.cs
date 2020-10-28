using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float aliveTime;
    public float damage;
    public float movSpeed;

    private GameObject enemyTriggered;

    // public GameObject bulletSpawn;
    // Start is called before the first frame update
    // Update is called once per frame
    // void start()
    // {
    //     bulletSpawn = GameObject.find("BulletSpawn");
    //     this.transform.rotation = bulletSpawn.transform.rotation;
    // }

    void Update()
    {
        aliveTime -= 1 * Time.deltaTime;

        if (aliveTime <= 0)
            Destroy(this.gameObject);

        this.transform.Translate(Vector3.forward * Time.deltaTime * movSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyTriggered = other.gameObject;
            enemyTriggered.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
