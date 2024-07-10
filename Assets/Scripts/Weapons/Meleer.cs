using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleer : MonoBehaviour
{
    [Header("Weapon Configuration")]
    public float cooldownTime = 1f;
    public float hitMomentum = 2f;
    public float hitDamage = 2f;

    [Header("Should primarily by updated by Scripts")]
    public GameObject meleePrefab;

    private GameObject bigStick;
    private Animator stickler;
    private float swingTime = 1; //how long the hitbox stays active
    private GameObject cam;
    private float lastAttacked = 0;

    public void replace() 
    {
        Destroy(bigStick);
    }

    public void RegenerateWeapon() {
        if (bigStick != null) {
            Destroy(bigStick);
        }

        bigStick = Instantiate(meleePrefab, transform.Find("Main Camera"), true);
        bigStick.transform.localPosition = bigStick.transform.Find("CamPos").position;
        bigStick.transform.rotation = Quaternion.LookRotation(transform.Find("Main Camera").forward,transform.Find("Main Camera").up) * bigStick.transform.rotation;

        stickler = bigStick.GetComponentInChildren<Animator>();
        
        if(stickler) 
        {
            RuntimeAnimatorController controller = stickler.runtimeAnimatorController;
            if(controller) 
            {
                AnimationClip[] clips = controller.animationClips;
                foreach (AnimationClip clip in clips)
                {
                    Debug.Log(clip.name);
                    if (clip.name == "Attack")
                    {
                        swingTime = clip.length;
                        break;
                    }
                }
            }
        }
    }

    void SwingStick() {
        stickler.SetTrigger("Attack");

        StickHitter dmgr = bigStick.GetComponentInChildren<StickHitter>();
        dmgr.hitTime = swingTime;
        dmgr.damage = hitDamage;
        dmgr.impulseTime = hitMomentum;
        dmgr.ignoreCollider = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = transform.Find("Main Camera").gameObject;
        if (cam == null) {
            Debug.Log("No Main Camera?");
            return;
        }

        RegenerateWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (Time.time - lastAttacked < (cooldownTime + swingTime)) return;
            lastAttacked = Time.time;

            SwingStick();
        } 
    }
}
