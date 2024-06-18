using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerArrow : MonoBehaviour
{
    [SerializeField] private int countArrow;

    private GameObject arrow;

    [SerializeField]List<Transform> position = new List<Transform>();

    [SerializeField] private GameObject arrowPrefab;

    private int counter;

    [SerializeField] private float timerToStartArrowUsers;
    private float timerArrowStart;

    public UnityAction arrowStartSound;

    private void Start()
    {
        foreach (Transform positionObj in position)
        {
            if (counter < countArrow)
            {
                counter++;
            }
            else
            {
                if(counter > 0)
                {
                    arrowStartSound?.Invoke();
                }
                return;
            }

            Instantiate(arrowPrefab, positionObj);
        }
    }

    private void Update()
    {
        timerArrowStart += Time.deltaTime;

        if(timerArrowStart >= timerToStartArrowUsers)
        {
            spawnObject();
            arrowStartSound?.Invoke();
            timerArrowStart = 0;
        }
    }

    private void spawnObject()
    {
        foreach (Transform positionObj in position)
        {
            Instantiate(arrowPrefab, positionObj);
        }
    }
}
