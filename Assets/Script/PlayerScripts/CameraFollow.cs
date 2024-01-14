using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player's transform to follow
    public float minX = -2.745f; // The minimum X position for the camera
    public float maxX = 2.326f;

        private void LateUpdate()
        {
            if (target != null)
            {
                // Calculate the desired camera position
                // this is used in the HouseScene so the camera doesnt go off and show the end of the house art and show the blank space 
                // keep the camera in frame with the player and follow him around 
                Vector3 desiredPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);

                // Ensure the camera doesn't go beyond the specified minimum and maximum X positions
                desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);

                // Set the camera's position to the desired position
                transform.position = desiredPosition;
            }
        }

    
}