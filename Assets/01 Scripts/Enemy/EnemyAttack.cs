using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float _enemyDmg = 1;
 
    

    private void OnCollisionStay2D(Collision2D collision)
    {

        IGetHit objectCanGetHit = collision.gameObject.GetComponent<IGetHit>();
        if (objectCanGetHit != null)
        {
            Debug.Log("get hit");
            objectCanGetHit.GetHit(_enemyDmg);
        }
        else
        {
            Debug.Log("dont get hit");
        }

    }

}
