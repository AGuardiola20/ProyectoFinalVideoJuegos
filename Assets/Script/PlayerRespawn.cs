using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPositionX, checkPositionY;
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPositionX")!=0)
        {
            transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPositionX"), PlayerPrefs.GetFloat("checkPositionY")));
        }
    }
    public void ReachedCheckPoint( float x, float y)
    {
        PlayerPrefs.SetFloat("checkPositionX", x);
        PlayerPrefs.SetFloat("checkPositionY", y);
    }
}
