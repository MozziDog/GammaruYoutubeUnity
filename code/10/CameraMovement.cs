using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float smoothTime;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float position_x, position_y;
        float tmp_x=0, tmp_y = 0;
        position_x = Mathf.SmoothDamp(gameObject.transform.localPosition.x,
                                    player.transform.localPosition.x, ref tmp_x, smoothTime, 10);
        position_y = Mathf.SmoothDamp(gameObject.transform.localPosition.y,
                                    player.transform.localPosition.y, ref tmp_y, smoothTime, 10);
        position_x = Mathf.Clamp(position_x, minPosition.x, maxPosition.x);
        position_y = Mathf.Clamp(position_y, minPosition.y, maxPosition.y);
        gameObject.transform.localPosition = new Vector3(position_x, position_y, gameObject.transform.localPosition.z);
    }
}
