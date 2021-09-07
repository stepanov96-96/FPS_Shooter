using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyLife : MonoBehaviour
{
    [SerializeField]
    private static EnemyLife Instance;

    [SerializeField]
    private TextMeshProUGUI healthEnemyText;

    [SerializeField]
    private GameObject CurrentGameObject;

    private Transform curentTrasform;

    private float HealthEnemy;


    private bool explosionDone;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        HealthEnemy = 100f;
        Invoke("Save", 2f);

 
    }

    void SavePosition()
    {
        curentTrasform.position = new Vector3( transform.position.x, transform.position.y, transform.position.z);
    }

    public void DamageEnemy(float damage)
    {
        if (explosionDone)
            return;
        explosionDone = true;

        HealthEnemy -= damage;
        healthEnemyText.text = "" + HealthEnemy;



        if (HealthEnemy <= 0)
        {
            Invoke("RespawObject", Random.Range(5,10));
            gameObject.SetActive(false);
            UIScripts.Instance.Score();

        }

        if (gameObject.activeSelf)
        {
            StartCoroutine(HealthReturn());
        }

    }
    private void RespawObject()
    {
        gameObject.SetActive(true);
        HealthEnemy = 100;
        healthEnemyText.text = "" + HealthEnemy;
        
        
    }


    IEnumerator HealthReturn()
    {
            yield return new WaitForSeconds(1f);
        explosionDone = false;
    }

   
}
