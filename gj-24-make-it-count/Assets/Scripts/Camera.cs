using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public int xMin = 5;
    public int yMin = 5;

    public Transform target;
    private Vector3 offset = new Vector3 (0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.3f;
    public Rigidbody2D playerBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.x += playerBody.velocity.x * 0.50f;
        if (targetPosition.x < xMin)
        {
            targetPosition.x = xMin;
        }
        if (targetPosition.y < yMin)
        {
            targetPosition.y = yMin;
        }


        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        // move to target
        
    }
}
