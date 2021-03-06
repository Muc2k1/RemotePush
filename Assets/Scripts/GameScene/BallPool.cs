using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPool : MonoBehaviour
{
    public static NormalBall[] Balls = new NormalBall[MAX_BALLS_IN_POOL];
    private const int MAX_BALLS_IN_POOL = 84; 
    void Awake()
    {
        for (int i = 0; i < MAX_BALLS_IN_POOL; i++)
        {
            Balls[i] = transform.GetChild(i).gameObject.GetComponent<NormalBall>();
        }
    }

    static public NormalBall TakeMyBall()
    {
        for (int i = 0; i < MAX_BALLS_IN_POOL; i++)
        {     
            if(Balls[i].status == NormalBall.STATUS.Idle)
            {
                Balls[i].status = NormalBall.STATUS.Using;
                return Balls[i];
            }       
        }
        return null;
    }
    static public void GiveBackBall(NormalBall Ball)
    {
        Ball.status = NormalBall.STATUS.Idle;
        // Debug.Log("Back from: " + Ball + " By node: " + Ball.GetMyStand());
        if(Ball.GetMyStand())
        {
            Ball.GetMyStand().nextSpawnBall = null;
        }
        Ball.gameObject.SetActive(false);
    }

    // static public NormalBall RefreshPool()
    // {
    //     for (int i = 0; i < MAX_BALLS_IN_POOL; i++)
    //     {     
    //         if(Balls[i].status == NormalBall.STATUS.Idle)
    //         {
    //             if(Balls[i].GetMyStand())
    //             {
    //                 Balls[i].GetMyStand().SetMyBall(null);
    //                 Balls[i].SetMyStand(null);
    //             }
    //         }       
    //     }
    //     return null;
    // }
}
