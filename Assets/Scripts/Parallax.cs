using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, ypos;
    public GameObject cam;
    public float ParallaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        ypos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - ParallaxEffect));
        float dist = (cam.transform.position.x * ParallaxEffect);
        float ydist = (cam.transform.position.y * ParallaxEffect);
        transform.position = new Vector3(startpos + dist, ypos + ydist, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}