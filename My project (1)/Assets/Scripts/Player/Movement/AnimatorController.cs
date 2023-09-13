using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    private PlayerRotaion2 player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<PlayerRotaion2>();
    }

    private void Update()
    {
        animator.SetFloat("x", player.InputDirection.x);
        animator.SetFloat("y", player.InputDirection.z);
    }
}
