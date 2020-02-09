using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{
    private Animation animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animation>();
        StartCoroutine(TriggerNewAnimation());
    }

    private IEnumerator TriggerNewAnimation()
    {
        yield return new WaitForSeconds(animator.clip.length);
        Debug.LogFormat("FINISH AFTER {0}", animator.clip.length);
    }
}
