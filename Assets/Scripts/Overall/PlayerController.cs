using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed = 40f;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private GameObject gunEffect;

    public int heartsNum = 3;

    float horizontalMove = 0f;
    bool gunEffectCheck = false;

    bool jump;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //Lấy trục tọa độ => Khi bấm A hoặc mũi tên bên trái thì horizontalMove = -1; bấm D hoặc mũi tên bên phải thì horizontalMove = 1
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
                StartCoroutine(DelayGunEffect()); //hiệu ứng bắn súng hiện ra
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            playerAnim.SetBool("jump", true);
            StartCoroutine(DelayJump());
        }
    }

    IEnumerator DelayJump()
    {
        yield return new WaitForSeconds(0.5f);
        jump = false;
        playerAnim.SetBool("jump", false);
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
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //Gọi script còn lại để add lực để đẩy vào nhân vật
    }

    private void OnCollisionEnter2D(Collision2D collision) //xử lý va chạm với quái
    {
        if (collision.gameObject.tag == "Enemy")
        {
            heartsNum--; //trừ mạng nếu chạm phải enemy
        }
    }
}
