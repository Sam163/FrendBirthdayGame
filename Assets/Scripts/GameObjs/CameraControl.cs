using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private Transform m_Target; // Reference to the player's transform.

    public float xMargin = 1f; // Distance in the x axis the player can move before the camera follows.
    public float yMargin = 1f; // Distance in the y axis the player can move before the camera follows.
    public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
    public float ySmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
    public float xOffset = 0f;
    public float yOffset = 3f;
    public Vector2 maxXAndY; // The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY; // The minimum x and y coordinates the camera can have.
    void Start()
    {
            m_Target = GameObject.FindGameObjectWithTag("Player").transform.FindChild("CeilingCheck");
    }

    private bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - m_Target.position.x-xOffset) > xMargin;
    }


    private bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - m_Target.position.y-yOffset) > yMargin;
    }


    private void Update()
    {
        TrackPlayer();
    }


    private void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, m_Target.position.x+xOffset, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, m_Target.position.y+yOffset, ySmooth * Time.deltaTime);
        }
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
