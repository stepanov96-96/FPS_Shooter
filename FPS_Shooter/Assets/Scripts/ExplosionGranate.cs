using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionGranate : MonoBehaviour
{
    [SerializeField]
    private float radius;

    [SerializeField]
    private float force;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float groundDistance = 0.4f;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private GameObject[] explosionEffects;


    private bool isGrounded;

    private bool explosionDone;

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            Invoke("Explode", 0.5f);

        }        

    }

   

    void Explode()
    {

        if (explosionDone)
            return;
        explosionDone = true;

        Destroy(Instantiate(explosionEffects[GrenadeChoice.currentItem], transform.position, Quaternion.identity),4);

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

            if (nearbyObject.tag == "Enemy")
            {
                DamageEnemy(nearbyObject.transform);

            }

        }

        Destroy(gameObject);
    }



    void DamageEnemy(Transform enemy)
    {
        EnemyLife e = enemy.GetComponent<EnemyLife>();

        if (e != null)
        {
            float damage = GrenadeChoice.damageGrenade;
            e.DamageEnemy(damage);

        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = new Color(1f, 1f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, radius / 2f);
    }
}
