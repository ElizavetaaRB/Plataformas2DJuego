using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlataform : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    [SerializeField] int direction;

    [SerializeField] private float speed;
    private void Update()
    {
        Vector2 target = currentMovementTarget();

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        

        float distance = (target -(Vector2)transform.position).magnitude;

        if(distance < 0.1f)
        {
            direction *= -1;
        }
    }



    Vector2 currentMovementTarget()
    {
        if(direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }



    private void OnDrawGizmos()
    {
        if(this != null && startPoint!=null && endPoint != null)
        {
            Gizmos.DrawLine(transform.position, startPoint.position);
            Gizmos.DrawLine(transform.position, endPoint.position);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D elotro)
    {
        if (elotro.gameObject.CompareTag("PlayerDetection") || elotro.gameObject.CompareTag("PlayerAreaCuerpo") )
        {
                elotro.transform.SetParent(this.transform);
            }

      

    }


    private void OnCollisionExit2D(Collision2D elotro)
    {
        if (elotro.gameObject.CompareTag("PlayerDetection") || elotro.gameObject.CompareTag("PlayerAreaCuerpo"))
        {
            elotro.transform.SetParent(null);

        }
                
    }
    
}
