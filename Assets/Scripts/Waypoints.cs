using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] multiWays;
    public static Transform[] firstWay;
    public static Transform[] secondWay;
    public static Transform[] thirdWay;
    public int getWaysCount()
    {
        return multiWays.Length;
    }
}
