using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common : MonoBehaviour
{
    public static void FloorSpawn(GameObject GrassLand,float i,float j,GameObject Group)
    {
        
        Instantiate(GrassLand, new Vector3(i, j, 0), Quaternion.identity, Group.transform);
    }
 



}
