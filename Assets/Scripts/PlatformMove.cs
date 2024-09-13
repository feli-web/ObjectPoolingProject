using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float moveSpeedY;
    private MeshRenderer meshrenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshrenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshrenderer.material.mainTextureOffset = new Vector2(0f, Time.realtimeSinceStartup * -moveSpeedY);
    }
    public void Stop()
    {
        moveSpeedY = 0f;
    }
}
