using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpaw : MonoBehaviour
{
    public static GrenadeSpaw Instance;
    [SerializeField]
    private GameObject[] spawRedGrenade;

    [SerializeField]
    private GameObject[] spawBlueGrenade;

    [SerializeField]
    private GameObject[] spawGreenGrenade;

    [SerializeField]
    private GameObject[] grenade;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SpowRed();
        SpowBlue();
        SpowGreen();

        StartCoroutine(RespawGrenade());
    }


    public void SpowRed()
    {
        for (int i = 0; i < spawRedGrenade.Length; i++)
        {
            Destroy(Instantiate(grenade[0], spawRedGrenade[i].transform.position, Quaternion.identity),30);
        }

    }

    public void SpowBlue()
    {
        for (int i = 0; i < spawBlueGrenade.Length; i++)
        {
            Destroy(Instantiate(grenade[1], spawBlueGrenade[i].transform.position, Quaternion.identity), 30);
        }
    }

    public void SpowGreen()
    {
        for (int i = 0; i < spawGreenGrenade.Length; i++)
        {
            Destroy(Instantiate(grenade[2], spawGreenGrenade[i].transform.position, Quaternion.identity), 30);
        }
    }

    IEnumerator RespawGrenade()
    {
        yield return new WaitForSeconds(30f);
        Start();
    }
}
