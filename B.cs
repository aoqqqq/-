using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(LineRenderer))]
public class B : MonoBehaviour
{
    //
    public bool ON_OFF = true;
    public int pos = 0;
    public int pos1;
    public float speed;
    public float sp;
    public int zq = 0;
    public int z1 = 0;
    public int z2 = 0;
    public float tim;
    public Transform[] gameobj;//贝塞尔对象

    public int[] objindex;
    //……………………………………………………………………
    public GameObject Objects;
    public int point = 50;//点数
    //public int tc = 0;//图层
    //private LineRenderer LR;//画图
    public int index = 0;
    //……………………………………………………………………
    public Vector3[] v2;//点的位置

    public GameObject[] scobj;
    private void Start()
    {
        //if (true)
        //{
        //    LR = GetComponent<LineRenderer>();

        //}
        //LR.sortingLayerID = tc;
        upbs3();
        scobj = new GameObject[v2.Length];
        objindex = new int[v2.Length];
        for (int i = 0; i < v2.Length; i++)
        {
            index = i;
            scobj[i] = Instantiate(Objects, v2[i], new Quaternion(0, 0, 0, 0), transform);

        }
    }
    void upbs2()
    {
        List<Vector3> list = new List<Vector3>(point * 2);

        Vector3[] v = BC.bc2point_position(gameobj[0].position, gameobj[1].position, gameobj[5].position, point);
        Vector3[] v1 = BC.bc2point_position(gameobj[0].position, gameobj[4].position, gameobj[5].position, point);


        for (int i1 = 0; i1 < v.Length; i1++)
            list.Add(v[i1]);

        for (int i2 = v1.Length - 1; i2 >= 0; i2--)
            list.Add(v1[i2]);


        v2 = new Vector3[v.Length + v1.Length];
        int i = 0;
        foreach (Vector3 item in list)
        {
            v2[i] = item;

            i++;
        }
        //LR.SetPositions(v2);
        //Debug.Log(v2.Length);
        //LR.positionCount = v2.Length ;
    }
    void upbs3()
    {
        List<Vector3> list = new List<Vector3>(point);

        Vector3[] v = BC.bc3point_position(gameobj[0].position, gameobj[1].position, gameobj[2].position, gameobj[5].position, point);
        Vector3[] v1 = BC.bc3point_position(gameobj[0].position, gameobj[3].position, gameobj[4].position, gameobj[5].position, point);


        for (int i1 = 0; i1 < v.Length - 1; i1++)
            list.Add(v[i1]);

        for (int i2 = v1.Length - 1; i2 > 0; i2--)
            list.Add(v1[i2]);


        v2 = new Vector3[v.Length + v1.Length - 2];
        int i = 0;
        foreach (Vector3 item in list)
        {
            v2[i] = item;
            i++;
        }
        pos1 = v2.Length;
        //LR.SetPositions(v2);
        //Debug.Log(v2.Length);
        //LR.positionCount = v2.Length ;
    }
    public bool updatpos()
    {

        if (z1 >= v2.Length)
        {

            for (int i = 0; i < v2.Length; i++)
            {
                scobj[i].transform.position = v2[objindex[i]];
            }
            z1 = 0;
            tim = 0;
        }
        switch (z1)
        {
            case 0:
                return true;
            default:
                return false;
        }


    }

    private void Update()
    {
        tim += Time.deltaTime;
        Debug.Log(tim + "tim");
        pos1 = v2.Length;

    }

    private void FixedUpdate()
    {
        sp = speed;
        upbs3();
    }
}

