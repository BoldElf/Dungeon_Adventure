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
        //���� ��������� ���� � ����������� ����, ���� ��� �����
        RaycastHit hit;
        //��� ���, ���������� �� ������� ����� ������� � ��������� � ������� ����
        Ray ray = new Ray(transform.position, target.position - transform.position);
        //������� ���
        Physics.Raycast(ray, out hit);

        //���� ��� � ���-�� ��������, ��..
        if (hit.collider != null)
        {
            //���� ��� �� ����� � ����
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
            //���� ��� ����� � ����
            else
            {
                if(wall_01 != null)
                {
                    wall_01.enabled = true;
                    wall_01 = null;
                    useNumber_01 = null;
                }
            }
            //������ ��� ����������� ������ ��� � ���� Scene
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }

}
