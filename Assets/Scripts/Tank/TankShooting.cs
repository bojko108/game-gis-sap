using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    [Tooltip("Set bullet initial velocity")]
    public float Velocity = 150f;
    [Tooltip("Gun damage")]
    public int DamagePerShot = 20;
    [Tooltip("Gun fire rate in seconds")]
    public float FireRate = 1f;
    [Tooltip("Played when the gun fires")]
    public AudioClip FireSound;
    [Tooltip("Played when the gun misfire")]
    public AudioClip MisfireSound;
    [Tooltip("Played when the gun is realoded and ready to fire")]
    public AudioClip ReadyToFireSound;
    [Tooltip("Used to visualising gun reloading progress")]
    public Slider ReloadSlider;
    [Tooltip("Bullets initial position - place this infront of the gun")]
    public Transform GunTransform;
    
    private AudioSource gunSoundSource;
    private TankControlScript tankControl;

    private bool canShoot = false;
    private float timer;

    private void Awake()
    {
        this.gunSoundSource = this.gameObject.GetComponent<AudioSource>();
        this.tankControl = this.GetComponent<TankControlScript>();

        this.ReloadSlider.maxValue = this.FireRate;
        this.ReloadSlider.minValue = 0;

        StartCoroutine(this.Reload());
    }

    private void Update()
    {
        if (this.tankControl.DisableGun) return;

        if (Input.GetButtonDown("Fire1"))
        {
            if (this.canShoot)
            {
                this.Shoot();
            }
            else
            {
                if (this.MisfireSound)
                {
                    this.gunSoundSource.clip = this.MisfireSound;
                    this.gunSoundSource.Play();
                }

                this.timer = 0f;
            }
        }
    }

    private void Shoot()
    {
        this.canShoot = false;
        
        GameObject bullet = this.GetBullet();
        bullet.transform.position = this.GunTransform.position;
        bullet.transform.rotation = this.GunTransform.rotation;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * this.Velocity;

        if (this.FireSound)
        {
            this.gunSoundSource.clip = this.FireSound;
            this.gunSoundSource.Play();
        }

        this.StartCoroutine(this.Reload());
    }

    private IEnumerator Reload()
    {
        this.timer = 0f;
       
        while (this.canShoot == false)
        {
            this.timer += Time.deltaTime;

            this.ReloadSlider.value = this.timer;

            if (this.timer >= this.FireRate)
            {
                this.canShoot = true;

                if (this.ReadyToFireSound)
                {
                    this.gunSoundSource.clip = this.ReadyToFireSound;
                    this.gunSoundSource.Play();
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private GameObject GetBullet()
    {
        GameObject bullet = ObjectPooler.Current.GetPooledObject();

        if (bullet != null)
        {
            bullet.SetActive(true);
        }

        return bullet;
    }
}
