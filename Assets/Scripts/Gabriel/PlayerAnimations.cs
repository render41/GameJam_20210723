using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private MovePlayer movePlayer;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.movePlayer = GameObject.Find("Player").GetComponent<MovePlayer>();
    }

    private void Update()
    {
        if (this.movePlayer.direction != Vector3.zero)
        {
            this.animator.SetFloat("Horizontal", this.movePlayer.direction.x);
            this.animator.SetFloat("Vertical", this.movePlayer.direction.y);
        }

        if (this.movePlayer.direction.x > 0 || this.movePlayer.direction.y > 0 || this.movePlayer.direction.x < 0 || this.movePlayer.direction.y < 0)
        {
            this.animator.SetFloat("Speed", this.movePlayer.moveSpeed);
        }
        else
        {
            this.animator.SetFloat("Speed", 0);
        }

    }
}
