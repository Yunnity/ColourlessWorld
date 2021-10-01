using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim != null)
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Destroy(anim);
                Destroy(gameObject);
            }
        }
    }
}
