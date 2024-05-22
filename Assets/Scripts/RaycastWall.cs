using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWall : MonoBehaviour
{
    [SerializeField]private Transform target;

    // private MeshRenderer[] wall;
    private MeshRenderer wall_01; 
    private string useNumber_01;

    void Update()
    {
        //сюда запишется инфо о пересечении луча, если оно будет
        RaycastHit hit;
        //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        Ray ray = new Ray(transform.position, target.position - transform.position);
        //пускаем луч
        Physics.Raycast(ray, out hit);

        //если луч с чем-то пересёкся, то..
        if (hit.collider != null)
        {
            //если луч не попал в цель
            if (hit.collider.gameObject != target.gameObject && hit.collider.tag == "Wall")
            {
                /*
                wall_01 = hit.collider.gameObject.GetComponent<MeshRenderer>();
                useNumber_01 = hit.collider.gameObject.name;
                */

                if(hit.collider.gameObject.name != useNumber_01)
                {
                    if (wall_01 != null)
                    {
                        wall_01.enabled = true;
                    } 
                    wall_01 = hit.collider.gameObject.GetComponent<MeshRenderer>();
                    useNumber_01 = hit.collider.gameObject.name;
                }
                
                if(wall_01 != null)
                {
                    wall_01.enabled = false;
                }
            }
            //если луч попал в цель
            else
            {
                if(wall_01 != null)
                {
                    wall_01.enabled = true;
                    wall_01 = null;
                    useNumber_01 = null;
                }
            }
            //просто для наглядности рисуем луч в окне Scene
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }

}
