using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
	private float duration;
    private float time;
    private bool finish = false;
    private bool start = false;

    public bool Finished
    {
        get
        {
            return finish;
        }
    }

	public void Begin(float delay) {
		duration = delay;
        start = true;
    }

    void Update()
    {
        if (start)
        {
            start = false;
            finish = false;
            time = duration;
        }
        time -= Time.deltaTime;
        if (time < 0)
        {
            finish = true;
        }
    }
}