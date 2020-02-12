using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCRTL : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    SpriteRenderer sr;
    Animator anim;
    public float jump;
    public float slideY;
    public float player;
    public float player1;
    public SaveData data;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = Input.GetAxisRaw("Horizontal");
        player1 = Input.GetAxisRaw("Vertical");
        player *= speed;
        if(player != 0) { MoveHorizontal(player); }
        else { StopPlayer(); }
        if (Input.GetKeyDown(KeyCode.E)) { Jump1(); }
        else { jumpdown(); }
        if(player1 > 0) { Jump(player1); }
        else { jumpdown(); }
        if (player1 < 0) { slider(player1); }
        else { stopslider(); }

        

    }
    public void MoveHorizontal(float player)
    {
        rb.velocity = new Vector2(player,rb.velocity.y);
        if(player < 0) { sr.flipX = true; }
        if(player > 0) { sr.flipX = false; }
        anim.SetBool("walk", true);
    }
    public void StopPlayer()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetBool("walk", false);
    }
    public void Jump(float player1)
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        anim.SetBool("jump", true);
    }
    public void jumpdown()
    {
        anim.SetBool("jump", false);
    }
    public void Jump1()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        anim.SetBool("jump", true);
    }
    public void slider(float player1)
    {
        anim.SetBool("Slide", true);
    }
    public void stopslider()
    {
        anim.SetBool("Slide", false);
    }
}
