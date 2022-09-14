using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject playerObj;
    private Player player;
    private Transform playerTransform;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.25f;

    // Start is called before the first frame update
    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        playerTransform = playerObj.transform;
    }

    private void Update()
    {
        if (playerTransform != null && !player.animator.GetCurrentAnimatorStateInfo(0).IsName("MajoIdle"))
        {
            Vector3 targetPostion = playerTransform.position + new Vector3(0, 0, -10f);

            transform.position = Vector3.SmoothDamp(transform.position, targetPostion, ref velocity, smoothTime);
        }
    }
}
