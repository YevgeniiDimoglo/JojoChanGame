using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float smoothTime = 0.25f;
    [SerializeField] private float x_dist = 0.5f;
    private float smoothTime_adjustment;
    private float x_dist_adjustment;
    private GameObject playerObj;
    private Player player;
    private Transform playerTransform;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        playerTransform = playerObj.transform;
        smoothTime_adjustment = smoothTime;
        x_dist_adjustment = x_dist;
    }

    private void Update()
    {
        Camera camera = gameObject.GetComponent<Camera>();
        if (player.CameraControl)
        {
            if (camera.orthographicSize < 4.0f)
            {
                camera.orthographicSize += 0.05f;
            }
            else
            {
                camera.orthographicSize = 4.0f;
            }
            transform.position += new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        }
        else
        {
            if (camera.orthographicSize > 3.0f)
            {
                camera.orthographicSize -= 0.05f;
            }
            else
            {
                camera.orthographicSize = 3.0f;
            }

            float PlayerSpeed = player.GetComponent<Rigidbody2D>().velocity.magnitude;
            if (PlayerSpeed > 15.0f)
            {
                smoothTime_adjustment *= 0.98f;
                x_dist_adjustment *= 0.98f;
                if (smoothTime_adjustment <= 0.01 && smoothTime_adjustment >= -0.01)
                {
                    smoothTime_adjustment = 0;
                }
                if (x_dist_adjustment <= 0.05 && x_dist_adjustment >= -0.05)
                {
                    x_dist_adjustment = 0;
                }
            }
            else
            {
                smoothTime_adjustment = smoothTime;
                x_dist_adjustment = x_dist;
            }

            Vector3 targetPostion = playerTransform.position + new Vector3(x_dist_adjustment * ((playerTransform.rotation.y < 0) ? -1.0f : 1.0f), 0, -10f); ;

            transform.position = Vector3.SmoothDamp(transform.position, targetPostion, ref velocity, smoothTime_adjustment);
        }

        foreach (Camera c in GetComponentsInChildren<Camera>())
        {
            c.orthographicSize = camera.orthographicSize;
        }
    }
}