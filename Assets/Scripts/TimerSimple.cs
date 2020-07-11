using UnityEngine;

// This is a struct so we can create arrays of timers without constructing each of them
public struct TimerSimple
{
    public float lifespan;
    public bool unscaled;
    private float timerLastUpdate;

    /// <summary>
    /// Returns true if the timer is running; even if it has elapsed.
    /// For example, if the timer has not been stopped (via Stop()), 
    /// and the timer has elapsed, this will still return true. 
    /// </summary>
    public bool isRunning { get; private set; }

    private float timer;

    public TimerSimple(float lifespan = 1f, bool unscaled = false)
    {
        this.lifespan = lifespan;
        this.unscaled = unscaled;
        this.isRunning = false;
        timer = 0;
        timerLastUpdate = 0;
    }

    public float elapsedTime
    {
        get
        {
            Update();
            return timer;
        }
    }

    public float remainingTime => lifespan - elapsedTime; 

    /// <summary>
    /// Is true IFF the timer has elapsed.
    /// </summary>
    public bool isTimerElapsed => elapsedTime >= lifespan;

    public float elapsedRatio
    {
        get
        {
            Debug.Assert(lifespan > float.Epsilon, "lifespan too short to compute ratio");
            return elapsedTime / lifespan;
        }
    }

    public float invElapsedRatio => 1f - elapsedRatio;

    public float elapsedRatioLooping => Mathf.Repeat(elapsedRatio, 1f);

    public float elapsedRatioLoopingPingPong
    {
        get
        {
            var t = Mathf.Repeat(elapsedRatio, 1f);
            return 2f * (t < .5f ? t : 1f - t);
        }
    }

    private void Update()
    {
        var currentTime = unscaled ? Time.unscaledTime : Time.time;
        if (isRunning)
        {
            timer += currentTime - timerLastUpdate;
        }
        timerLastUpdate = currentTime;
    }

    public void Stop()
    {
        isRunning = false;
    }

    public void Start(bool reset = true)
    {
        if (reset)
        {
            // When resetting, set 'running' to false to prevent the first
            // Update from reusing the previous timerLastUpdate.
            isRunning = false;

            timer = 0f;
        }
        Update();
        isRunning = true;
    }

    public void Start(float newLifespan, bool reset = true)
    {
        lifespan = newLifespan;
        Start(reset);
    }

    public void DelayedStart(float delay)
    {
        isRunning = false;
        timer = -delay;
        Update();
        isRunning = true;
    }

    public void FastForward(float x)
    {
        timerLastUpdate -= x;
    }

    public static TimerSimple StartNew(float lifespan = 1f, bool unscaled = false)
    {
        var t = new TimerSimple(lifespan, unscaled);
        t.Start();
        return t;
    }
}
