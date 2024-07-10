using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject item;
    public float freq;
    [SerializeField] Transform Player;

    public Transform enemyParent;

    float lastSpawnTime; 

    public int level;

    private  Transform[] children;

    public bool isDone;

    public int spawnAmmount;
    public int waveCount;

    public int coolDown;
    
    private float t;
    private bool onCoolDown;
    private int count;
    private int wave;

    // Start is called before the first frame update
    void Start() 
    {
        count = 0;
        wave = 1;
        isDone = false;
        // Get all child Transforms
        children = GetComponentsInChildren<Transform>();

        if(children.Length == 0 || (children[0] == transform && children.Length == 1)) 
        {
            Debug.Log("No children");
        }
        else 
        {
            foreach (Transform child in children)
            {
                if (child != this.transform) // Skip the parent itself
                {
                    Debug.Log(child.name);
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnTime + freq && count < spawnAmmount && !onCoolDown && wave <= waveCount) {
            Spawn();
            lastSpawnTime = Time.time;
        }
        if(count >= spawnAmmount && enemyParent.transform.childCount == 0 && !onCoolDown){
            t = Time.time;
            onCoolDown = true;
            if(wave >= waveCount){
                isDone = true;
            }
        }
        if(onCoolDown && Time.time-t >= coolDown){
            wave++;
            onCoolDown = false;
            count = 0;
        }
    }

    public void Spawn() 
    {
        if(children.Length == 0 || (children[0] == transform && children.Length == 1)) 
        {
            GameObject spawnedObj = Instantiate(item, transform.position, Quaternion.identity);
            spawnedObj.transform.SetParent(enemyParent.transform);
            EnemyAI e = spawnedObj.GetComponent<EnemyAI>();
            if(e != null) 
            {
                e.target = GameObject.FindGameObjectWithTag("Player").transform;
                //e.Terrain = GameObject.Find("ground").transform;
            }
            if(spawnedObj.GetComponent<EnemyHealth>() == null) 
            {
                spawnedObj.AddComponent<EnemyHealth>();
            }
            EnemyHealth h = spawnedObj.GetComponent<EnemyHealth>();
            h.health = 100.0f + (level - 1) * 10f;
            h.armor = (level - 1) * 10f;
            h.score = 10;
            count++;
        }
        else 
        {
            for(int i = 0; i < children.Length; i++) 
            {
                Vector3 target = children[i].position - Player.position;
                double angle = Mathf.Acos(Vector3.Dot(target, Player.forward)/target.magnitude);
                if(count < spawnAmmount && angle > Mathf.PI/2)
                {
                    GameObject spawnedObj = Instantiate(item, children[i].position, Quaternion.identity);
                    spawnedObj.transform.SetParent(enemyParent.transform);
                    EnemyAI e = spawnedObj.GetComponent<EnemyAI>();
                    if(e != null) 
                    {
                        e.target = GameObject.FindGameObjectWithTag("Player").transform;
                        //e.Terrain = GameObject.Find("ground").transform;
                    }
                    if(spawnedObj.GetComponent<EnemyHealth>() == null) 
                    {
                        spawnedObj.AddComponent<EnemyHealth>();
                    }
                    EnemyHealth h = spawnedObj.GetComponent<EnemyHealth>();
                    h.health = 100.0f + (level - 1) * 10f;
                    h.armor = (level - 1) * 10f;
                    h.score = 10;
                    count++;    
                }
                
            }
        }
        // GameObject spawnedObj = Instantiate(item, transform.position, Quaternion.identity);
        
        // EnemyBehavior e = spawnedObj.GetComponent<EnemyBehavior>();
        // if(e != null) 
        // {
        //     e.target = GameObject.FindGameObjectWithTag("Player").transform;
        //     e.Terrain = GameObject.Find("ground").transform;
        // }
        // if(spawnedObj.GetComponent<EnemyHealth>() == null) 
        // {
        //     spawnedObj.AddComponent<EnemyHealth>();
        // }
        // EnemyHealth h = spawnedObj.GetComponent<EnemyHealth>();
        // h.health = 100.0f + (level - 1) * 10f;
        // h.armor = (level - 1) * 10f;
    }
}

