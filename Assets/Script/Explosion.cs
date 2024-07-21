using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Explosion : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        AnimatorClipInfo info = animator.GetCurrentAnimatorClipInfo(0)[0];

        Destroy(gameObject, info.clip.length);
    }
}
