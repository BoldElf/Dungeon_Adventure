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
        //���� ��������� ���� � ����������� ����, ���� ��� �����
        RaycastHit hit;
        //��� ���, ���������� �� ������� ����� ������� � ��������� � ������� ����
        Ray ray = new Ray(transform.position + new Vector3(0, 0.8f, 0), transform.forward);
        //������� ���
        Physics.Raycast(ray, out hit, dist);

        //���� ��� � ���-�� ��������, ��..
        if (hit.collider != null)
        {
            //���� ��� �� ����� � ����
            if (hit.collider.gameObject != null)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    HitProcessingInvoke?.Invoke(hit.collider.tag);
                }
                
                //Debug.Log(hit.collider.name);
            }
            //���� ��� ����� � ����
            else
            {

            }
            //������ ��� ����������� ������ ��� � ���� Scene
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
}
