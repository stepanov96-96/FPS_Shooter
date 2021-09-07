using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealthText : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private TextMeshProUGUI text;

    void Update()
    {
        text.transform.LookAt(player);
        text.transform.rotation = player.rotation;
    }

  
}
