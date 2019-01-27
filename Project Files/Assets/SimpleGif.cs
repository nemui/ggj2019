using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleGif : MonoBehaviour
{
    public SpriteRenderer target;
    public Sprite[] frames;
    public int fps;

    private int frameIndex;
    private float timePile;
    private float frameTime;

    private void Start()
    {
        frameTime = 1f / fps;
        frameIndex = 0;
        timePile = 0;
        target.sprite = frames[frameIndex];
    }

    private void Update()
    {
        timePile += Time.deltaTime;
        if (timePile >= frameTime)
        {
            timePile = 0;
            frameIndex = (frameIndex + 1) % frames.Length;
            target.sprite = frames[frameIndex];
        }
    }
}
