using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private int enemiesLayer;
    private Rigidbody bulletBody;

    public void Awake()
    {
        this.bulletBody = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;

        if (hit != null && hit.CompareTag("GisPlayer") == false)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        // after a collision, velocity parameters get changed...
        this.bulletBody.velocity = Vector3.zero;
        this.bulletBody.angularVelocity = Vector3.zero;
    }
}
