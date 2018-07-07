using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform Player;
    public float Distance = 10f;
    public float Height = 5f;
    public float CameraSpeed = 10f;
    public float RotationSpeed = 10f;

    void LateUpdate()
    {
        if (Player)
        {
            Vector3 relativePosition = Player.position - this.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePosition);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * this.RotationSpeed * 0.1f);
            Vector3 targetPosition = Player.transform.position + Player.transform.up * this.Height -
                                     Player.transform.forward * this.Distance;

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition,
                Time.deltaTime * this.CameraSpeed * 0.1f);
        }
    }
}
