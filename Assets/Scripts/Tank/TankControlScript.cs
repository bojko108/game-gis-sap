using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControlScript : MonoBehaviour
{
    public Transform Turret;

    public float MovementSpeed = 10f;
    public float MaxSpeed = 20f;
    public float RotationSpeed = 10f;
    public bool TurretRotate = true;
    public float TurretRotationSpeed = 10f;
    public float JumpForce = 10f;
    [HideInInspector]
    public bool DisableGun = false; // while moving at max speed fire with the gun is disabled
    //public float MaxAttackAngle = 30f;

    private Rigidbody rigBody;
    private bool stopMovement = false;// used when SPACE is hit - the tank is upsidedown

    //private float bearing = 0f;

    private void Start()
    {
        this.rigBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        this.DisableGun = Input.GetKey(KeyCode.LeftShift);

        if (this.stopMovement)
            return;

        this.MoveTank();

        if (this.TurretRotate)
            this.RotateTurret();

        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(this.TryToGetUp());
    }

    private void MoveTank()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? this.MaxSpeed : this.MovementSpeed;

        float movement = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * this.RotationSpeed;

        this.rigBody.MovePosition(this.rigBody.position + this.transform.forward * movement);
        this.rigBody.MoveRotation(this.rigBody.rotation * Quaternion.Euler(0f, rotation, 0f));
    }

    private void RotateTurret()
    {
        if (this.Turret)
        {
            float bearing = Input.GetAxis("Mouse X") * this.TurretRotationSpeed * Time.deltaTime;

            this.Turret.Rotate(0f, bearing, 0f);



            //this.bearing += Input.GetAxis("Mouse X") * this.TurretRotationSpeed * Time.deltaTime;

            //this.bearing = Mathf.Clamp(this.bearing, -this.MaxAttackAngle, this.MaxAttackAngle);

            //Quaternion rotation = Quaternion.Euler(0f, this.bearing, 0f);
            //this.Turret.rotation = rotation;






            //float angle = Vector3.Angle(this.Turret.forward, this.transform.forward);

            //if (angle < this.MaxAttackAngle)
            //{
            //    float bearing = Input.GetAxis("Mouse X") * this.TurretRotationSpeed * Time.deltaTime;

            //    this.Turret.Rotate(0f, bearing, 0f);
            //}
            //else
            //{
            //    Debug.Log(angle);
            //    Debug.Log(this.MaxAttackAngle);
            //    this.Turret.eulerAngles = new Vector3(0f, angle, 0f);
            //}
        }
    }

    private IEnumerator TryToGetUp()
    {
       this.stopMovement = true;

        this.rigBody.AddForce(new Vector3(0, this.JumpForce, 0), ForceMode.Impulse);

        Quaternion rotation = Quaternion.Euler(0f, this.transform.rotation.eulerAngles.y, 0f);

        yield return new WaitForSeconds(1.5f);

        this.rigBody.MoveRotation(rotation);

        yield return new WaitForSeconds(0.5f);

        this.stopMovement = false;
    }
}
