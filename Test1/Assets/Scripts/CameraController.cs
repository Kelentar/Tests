﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Private Variables;
    private int lastX;
    private Transform player;
    #endregion

    #region Public Variables;
    public float dumping = 1.5f;
    public bool isLeft;
    public Vector2 offset = new Vector2(2f, 1f);
    #endregion

    // Доступ до числових значень границь
    //[SerializeField]
    //public float leftlimit;
    //[SerializeField]
    //public float rightlimit;
    //[SerializeField]
    //public float uplimit;
    //[SerializeField]
    //public float botlimit;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isLeft);
    }

    public void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        }
    }

    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX) isLeft = false; else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
        // Доповнення для границь камери 
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftlimit, rightlimit),
        //    Mathf.Clamp(transform.position.y, botlimit, uplimit),
        //    transform.position.z);
    }

    // Візуалізація границь для зручного використання
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawLine(new Vector2(leftlimit, uplimit), new Vector2(rightlimit, uplimit));
    //    Gizmos.DrawLine(new Vector2(leftlimit, botlimit), new Vector2(rightlimit, botlimit));
    //    Gizmos.DrawLine(new Vector2(leftlimit, uplimit), new Vector2(leftlimit, botlimit));
    //    Gizmos.DrawLine(new Vector2(rightlimit, uplimit), new Vector2(rightlimit, botlimit));
    //}

}