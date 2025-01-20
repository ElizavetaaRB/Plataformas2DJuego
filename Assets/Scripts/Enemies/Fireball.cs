using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float impulseball;
    [SerializeField] private Transform feetBall;
    [SerializeField] private float floordistance;
    [SerializeField] private LayerMask whatisFloor;
    [SerializeField] private int damageFireBall;
    public int DamageFireBall { get => damageFireBall; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // transform.forward -> Z (azul), up -> Y (verde) y right -> X (rojo)
        rb.AddForce(transform.right * impulseball, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (OnFloor())
        {
            //eliminar la bola o mejor en pool
            Destroy(gameObject);
        }
    }
    private bool OnFloor()
    {
        bool touch = Physics2D.Raycast(feetBall.position, Vector3.down, floordistance, whatisFloor);
        Debug.DrawRay(feetBall.position, Vector3.down, Color.red, 0.3f);
        return touch;
    }

    private void OnTriggerEnter2D(Collider2D elotro)
    {
        if (elotro.gameObject.CompareTag("PlayerDetection"))
        {
            Debug.Log("player detectado");
        }
        else if (elotro.gameObject.CompareTag("PlayerAreaCuerpo"))
        {
            Debug.Log("player atravesado");
            Destroy(gameObject); // DESTRUIR ESTE OBJETO O POOL
            LifeSystem sistemavidasPlayer = elotro.gameObject.GetComponent<LifeSystem>();
            sistemavidasPlayer.GetDamage(damageFireBall);
            if (sistemavidasPlayer.Lifes <= 0)
            {
                sistemavidasPlayer.QuitGAME();
            }
            else
            {
                sistemavidasPlayer.UiLifeplayer(sistemavidasPlayer.Lifes);
            }
        }
    }

}
