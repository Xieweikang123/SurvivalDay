using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAndNight : MonoBehaviour {

    public float changeTime =0.1f;  //更换图片间隔时间

    public Texture[] masks;
    public GameObject player; 

    private float timer = 0;
    private int i = 0;  //图片下标
    private bool isIncrease = true; //是否递增

    private float x;
    private float y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // print(Time.time);
        ChangeMask();

        //移动遮罩位置 
        //x  -70.6
        //y  -35.64
        x = player.transform.position.x / (-70.6f);
        y = player.transform.position.y / -35.64f;
        GetComponent<Renderer>().material.SetTextureOffset("_Mask", new Vector2(x, y));

    }

    //更改遮罩图片
    private void ChangeMask()
    {
        timer += Time.deltaTime;
        if (timer > changeTime)
        {
            GetComponent<Renderer>().material.SetTexture("_Mask", masks[i]);
            GetComponent<Renderer>().material.SetTexture("_Mask1", masks[i]);

            timer = 0;

            if (isIncrease)
                i++;
            else
                i--;
            if (i == masks.Length - 1)
                isIncrease = false;
            if (i == 0)
                isIncrease = true;
            //print(i);
        }
    }

}
