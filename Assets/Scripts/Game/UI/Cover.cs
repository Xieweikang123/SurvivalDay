using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour {


    private void OnTriggerStay2D(Collider2D collision)
    {
        //当玩家进入，通过玩家的Y轴与物体的Y轴大小，改变物体的层级
        if (collision.tag == "Player")
        {
            //print("playerEnter`");
            if (collision.transform.position.y > transform.position.y-0.5f)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            else
                GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }



}
