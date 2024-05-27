using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTrapMain : MonoBehaviour
{
    //[SerializeField] private DownTrap downTrap;
    private DownTrap downTrap;
    [SerializeField] private GameObject player;
    private Rigidbody playerRb;
    private PlayerMovmentV2_0 playerMovmentV2_0;

    private bool downTrapActive = false;
    private float timer;

    private void Start()
    {
        downTrap = GetComponentInChildren<DownTrap>();
        if(player != null)
        {
            playerRb = player.GetComponent<Rigidbody>();
            playerMovmentV2_0 = player.GetComponent<PlayerMovmentV2_0>();
        }
        downTrap.trapStart += startTrap;
    }

    private void startTrap()
    {
        downTrapActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (downTrapActive == true)
        {
            timer += Time.deltaTime;
            transform.position -= new Vector3(0, 10f, 0) * Time.deltaTime;
            playerMovmentV2_0.enabled = false;
            playerRb.AddForce(0f, -10f, 0f);

            if (timer >= 0.3f)
            {
                gameObject.SetActive(false);
                downTrapActive = false;
                timer = 0;
            }
            
        }
        
    }
}
