using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    private PlayerRotaion2 player;

    private void OnEnable()
    {
        MeaponManager.StartAtackEvent += OnStartedAttack;
        MeaponManager.EndAtackEvent += OnEndedAttack;
    }

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

    private void OnStartedAttack()
    {
        animator.SetBool("start attack", true);
    }
    private void OnEndedAttack()
    {
        animator.SetBool("start attack", false);
    }
    private void OnDisable()
    {
        MeaponManager.StartAtackEvent -= OnStartedAttack;
        MeaponManager.EndAtackEvent -= OnEndedAttack;
    }
}
