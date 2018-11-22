using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantHapticController : MonoBehaviour
{
    public AudioClip aclip;
    OVRHapticsClip hclip;

    private AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        hclip = new OVRHapticsClip(aclip);
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {   
        OVRHaptics.RightChannel.Preempt(hclip);
        yield return new WaitForSecondsRealtime(1);
        OVRHaptics.LeftChannel.Preempt(hclip);
        source.enabled = true;
    }
}
