using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove :PlayerState {

    private float xx=0;
    private float yy = 0;
    public static PlayerMove Instance;
	void Start ()
    {
        Instance = this;
    }
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        float y = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        transform.Translate(x, y, 0);
        transform.Translate(xx, yy, 0);

        //如果移动
        if (x != 0 || xx != 0 || y != 0 || yy != 0)
        {

        }
    }

    public  void Move(Vector3 dir)
    {
        //判断朝向
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
                direction = Direction.Right;
            else
                direction = Direction.Left;
        }
        else
        {

            if (dir.y > 0)
                direction = Direction.Up;
            else
                direction = Direction.Down;
        }
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
    }   
}
