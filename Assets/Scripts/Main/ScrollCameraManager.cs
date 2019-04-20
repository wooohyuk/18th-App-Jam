using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCameraManager : MonoBehaviour
{
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public Joystick joystick;

    public float scale = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float move = joystick.Vertical * scale * Time.deltaTime;
        print(move);
        Vector3 targetPosition = transform.TransformPoint(new Vector3(0, move));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
