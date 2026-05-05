using System.Threading;
using UnityEngine;
using TimeSpan = System.TimeSpan;

public sealed class HitchHelper : MonoBehaviour
{
    [SerializeField] private float hitchDuration;

    protected void TriggerHitch()
    {
        Debug.LogFormat(this, "Frame {0}: triggering {1}s hitch", Time.frameCount, hitchDuration);
        Thread.Sleep(TimeSpan.FromSeconds(hitchDuration));
    }
}
