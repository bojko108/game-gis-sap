using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public static Transform Target;
    public float Distance = 10f;
    public float Height = 5f;
    public float CameraSpeed = 10f;
    public float RotationSpeed = 10f;
    public Vector3 LookOffset = new Vector3(0, 1, 0);

    void LateUpdate()
    {
        if (Target)
        {
            Vector3 lookPosition = Target.position + this.LookOffset;
            Vector3 relativePosition = lookPosition - this.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePosition);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * this.RotationSpeed * 0.1f);
            Vector3 targetPosition = Target.transform.position + Target.transform.up * this.Height -
                                     Target.transform.forward * this.Distance;

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition,
                Time.deltaTime * this.CameraSpeed * 0.1f);
        }
    }
}
