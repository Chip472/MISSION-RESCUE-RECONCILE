using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed = 40f;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private GameObject gunEffect;

    float horizontalMove = 0f;
    bool gunEffectCheck = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horizontalMove != 0)
        {
            playerAnim.SetBool("run", true);
        }
        else
        {
            playerAnim.SetBool("run", false);
        }

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            if (!gunEffectCheck)
            {
                StartCoroutine(DelayGunEffect());
            }
        }
    }

    IEnumerator DelayGunEffect()
    {
        gunEffectCheck = true;
        playerAnim.SetBool("run", true);
        playerAnim.Play("BlitzRun", 0);
        gunEffect.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        gunEffect.SetActive(false);

        yield return new WaitForSeconds(0.1f);
        playerAnim.SetBool("run", false);
        gunEffectCheck = false;
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }
}
