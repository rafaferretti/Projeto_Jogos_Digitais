using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {
    private const int jump = 200;
    public Animator Anim;
    public Rigidbody2D rb;
    public RaycastHit2D collide;
    public BoxCollider2D cxcolisao;
	public char direcaotiro;

    //Shoting

        [SerializeField]
    private float shootingRate = 0.2f;
        [SerializeField]
    private float shotCooldown = 3;
    public Transform spawnBullet;
    public GameObject bullet;

    void Start()
    {
        Anim.SetBool("chao", true);
        Anim.SetBool("move", false);
        Anim.SetBool("atk", false);
		direcaotiro= 'D';
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCooldown > 0) {
            shotCooldown -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Anim.SetBool("atk", true);
            //SimpleAtk();
            shotCooldown = shootingRate;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            Anim.SetBool("atk", false);
        }

        if (NoChao())
        {
            Anim.SetBool("chao", NoChao());
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        Move(1.2f);
    }

    public void NoMove()
    {
        Anim.SetBool("move", false);
    }
    public void Move(float vel)
    {
        Anim.SetBool("move", false);
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * vel * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            Anim.SetBool("move", true);
			direcaotiro= 'D';
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * vel * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
            Anim.SetBool("move", true);
			direcaotiro= 'E';
		}
    }

    public void Jump()
    {
        Anim.SetBool("chao", false);
        rb.AddForce(transform.up* jump);
    }

    public bool NoChao()
    {
        collide = Physics2D.Raycast(transform.position,-transform.up,cxcolisao.size.y/2.1f);
        if (collide)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    public void SimpleAtk()
    {
        if (shotCooldown < 0)
        {
            if (bullet != null)
            {
				if (direcaotiro == 'D'){
                var cloneBullet = Instantiate(bullet,spawnBullet.position,Quaternion.identity);
                cloneBullet.transform.localScale = this.transform.localScale;
            }else{
				var cloneBullet = Instantiate(bullet,spawnBullet.position,Quaternion.identity);
                cloneBullet.transform.localScale = -this.transform.localScale;				
			}}
        }
    }
}
