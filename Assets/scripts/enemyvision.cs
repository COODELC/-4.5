using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class enemyvision : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField, Range(1f, 10f)]float vision;
    [SerializeField] LayerMask barrierlayer;
    [SerializeField] Transform ClosestBarrier;
    // Start is called before the first fram
    // e update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
        
        }
    }
    void checkForbarrier() 
    {
        Collider[] hitcolliders = Physics.OverlapSphere(transform.position, vision,barrierlayer);
        if (hitcolliders.Length > 0)
        {
            ClosestBarrier = null;
            float closetsdistanse = Mathf.Infinity;
            foreach (Collider collider in hitcolliders)
            {
                float distanse = Vector3.Distance(transform.position,collider.transform.position);
                if (distanse > closetsdistanse) 
                {
                    ClosestBarrier = collider.transform;
                }
            }
            if (ClosestBarrier != null) 
            {
                Vector3 dirrectiononB = ClosestBarrier.position - transform.position;
                
            }
        }
        else 
        {
        
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,vision);
    }
}
