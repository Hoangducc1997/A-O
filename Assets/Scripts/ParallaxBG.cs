using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{
    Transform cam; //Main Camera
    Vector3 camStartPos;
    float distance;

    GameObject[] backGrounds;
    Material[] mat;
    float[] backSpeed;
    float farthestBack;

    [Range(0.001f, 0.05f)]

    public float parallaxSpeed;
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backGrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backGrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backGrounds[i].GetComponent<Renderer>().material;

        }
        backSpeedCalculate(backCount);
    }

    void backSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) // find the farthest background
        {
            if ((backGrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backGrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0;i < backCount; i++) // Set the speed of backgrounds
        {
            backSpeed[i] = 1 - (backGrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);
        for(int i = 0; i < backGrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed); 
        }    
    }
}
