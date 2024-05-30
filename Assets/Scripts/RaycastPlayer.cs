using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastPlayer : MonoBehaviour
{
    private float dist = 3f;
    // private MeshRenderer[] wall;
    private MeshRenderer wall_01;
    private string useNumber_01;

    public UnityAction<string> HitProcessingInvoke;

    void Update()
    {
        //сюда запишется инфо о пересечении луча, если оно будет
        RaycastHit hit;
        //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        Ray ray = new Ray(transform.position + new Vector3(0, 0.8f, 0), transform.forward);
        //пускаем луч
        Physics.Raycast(ray, out hit, dist);

        //если луч с чем-то пересёкся, то..
        if (hit.collider != null)
        {
            //если луч не попал в цель
            if (hit.collider.gameObject != null)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    HitProcessingInvoke?.Invoke(hit.collider.tag);
                }
                
                //Debug.Log(hit.collider.name);
            }
            //если луч попал в цель
            else
            {

            }
            //просто для наглядности рисуем луч в окне Scene
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
}
