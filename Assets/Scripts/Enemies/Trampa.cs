using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] private float tiempoEntrDa�o;
    [SerializeField] private int damage;
    private float tiempoDa�onext;

    private void OnTriggerStay2D(Collider2D elotro)
    {
        if (elotro.gameObject.CompareTag("PlayerDetection") || elotro.gameObject.CompareTag("PlayerAreaCuerpo"))
        {
            tiempoDa�onext -=Time.deltaTime;
            if (tiempoDa�onext <= 0)
            {
                LifeSystem sistemavidasPlayer = elotro.gameObject.GetComponent<LifeSystem>();
                if (sistemavidasPlayer != null)
                {
                    sistemavidasPlayer.GetDamage(damage);
                    if (sistemavidasPlayer.Lifes <= 0)
                    {
                        sistemavidasPlayer.QuitGAME();
                    }
                    else
                    {
                        sistemavidasPlayer.UiLifeplayer(sistemavidasPlayer.Lifes);
                    }
                    tiempoDa�onext = tiempoEntrDa�o;
                }
            }
        }


    }
}
