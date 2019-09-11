using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform tr;
    [SerializeField]
    private Animator anim;
    public Transform verificaChao;
    public Transform verificaParede;

    [SerializeField]
    private bool estaNaParede;
    [SerializeField]
    private bool viradoParaDireita;
    [SerializeField]
    private bool estaNochao;
    [SerializeField]
    private int direcao=0;

    public float velocidade;
    public float raioValidaChao;
    public float raioValidaParede;

    public LayerMask solid;

    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        viradoParaDireita = true;
	}
	
	void FixedUpdate () {
        EnemyMove();
	}

    void Flip()
    {
        if (direcao == 0)
            direcao = 180;
        else
            direcao = 0;
        transform.eulerAngles = new Vector2(0, direcao);
        velocidade *= -1;
    }

	//Para Debug
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(verificaChao.position,raioValidaChao);
        Gizmos.DrawWireSphere(verificaParede.position, raioValidaParede);
    }
	//Movimento do inimigo
    void EnemyMove()
    {
        estaNochao = Physics2D.OverlapCircle(verificaChao.position,raioValidaChao,solid);
        estaNaParede = Physics2D.OverlapCircle(verificaParede.position, raioValidaParede, solid);

        if ((!estaNochao||estaNaParede)&&(viradoParaDireita))
        {
            Flip();
        }else if ((!estaNochao || estaNaParede) && (!viradoParaDireita))
        {
            Flip();
        }
        if (estaNochao)
        {
            rb.velocity = new Vector2(velocidade,rb.velocity.y);
        }
    }
	
	void OnCollisionEnter2D(Collision2D colisor) {
	if (colisor.gameObject.tag == "Tiro") {
		Destroy(gameObject);
	}
}
	
}
