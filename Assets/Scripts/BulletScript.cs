using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public AudioClip ExplosionSound;
    
    public float ExplosionForce = 1000f;
    public float ExplosionRadius = 5f;

    private AudioSource audioSource;
    
    private int enemiesLayer;
    private Rigidbody bulletBody;

    public void Awake()
    {
        this.bulletBody = this.GetComponent<Rigidbody>();
        
        this.enemiesLayer = LayerMask.GetMask(Resources.Layers.GisPlayers, Resources.Layers.SapPlayers);

        // get audio source
    }

    private void OnCollisionEnter(Collision collision)
    {
        // play explosion...
        GameObject explosion = GameObject.Instantiate(this.ExplosionPrefab, this.transform.position, this.transform.rotation);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(explosion, 3f);

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, this.ExplosionRadius, this.enemiesLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (targetRigidbody != null)
            {
                targetRigidbody.AddExplosionForce(this.ExplosionForce, this.transform.position, this.ExplosionRadius);

                // calculate damage
                // apply damage
            }
        }

        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        // after a collision, velocity parameters get changed...
        this.bulletBody.velocity = Vector3.zero;
        this.bulletBody.angularVelocity = Vector3.zero;
    }
}
