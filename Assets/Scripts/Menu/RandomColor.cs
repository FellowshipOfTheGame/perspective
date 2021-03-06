﻿using UnityEngine;
using System.Collections;


public class RandomColor : MonoBehaviour 
{
    public float Period = 2.0f;
    public AudioSource[] Clips;
    public float BrightnessCutoff = 0.6f;
    public float InitialShininess = 0.4f;
    private byte NextColor = 0;
    private float LastTimeChange;

    void Start()
    {
        LastTimeChange = Time.realtimeSinceStartup;
    }

	void Update ()
    {
        float Delta = Time.realtimeSinceStartup - LastTimeChange;
        if (Delta < Period / 3)
        {
            renderer.sharedMaterial.SetFloat("_Shininess", InitialShininess + (Delta*3/Period)*(1 - InitialShininess));
            return;
        }
        renderer.sharedMaterial.SetFloat("_Shininess", InitialShininess);
        foreach (AudioSource clip in Clips)
        {
            if(!clip.isPlaying)
                clip.Play();   
        }

        Color c;
        float Rand = Random.value;
        if (Rand > BrightnessCutoff)
            Rand = 1.0f - Rand;
        NextColor += (byte)(Random.value * 3);
        c = gameObject.renderer.sharedMaterial.color;
        c.r = Rand * Rand * Rand;
        c.g = Rand * Rand * Rand;
        c.b = Rand * Rand * Rand;
        if(NextColor%3 == 0)
            c.r = Rand * Rand;
        else if (NextColor % 3 == 1)
            c.g = Rand * Rand;
        else if (NextColor % 3 == 2)
            c.b = Rand * Rand;
        gameObject.renderer.sharedMaterial.color = c;
        LastTimeChange = Time.realtimeSinceStartup;
	}
}
