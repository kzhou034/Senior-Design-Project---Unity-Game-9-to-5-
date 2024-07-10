using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public UnityEngine.AI.NavMeshAgent agent;
    
    private Animator animController;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animController = GetComponentInChildren<Animator>();
        
        animController.SetBool("Walking", true);
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;

        if ((transform.position - target.position).magnitude < 2) {
            animController.SetBool("InAttackRange", true);
        } else {
            animController.SetBool("InAttackRange", false);
        }
    }
}
