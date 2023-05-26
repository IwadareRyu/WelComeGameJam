using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uwaaaaa : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 PlayerPosition;
    private Vector3 EnemyPosition;
    // Start is called before the first frame update
    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");

        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;
    }
    private void Update()
    {
        PlayerPosition = playerObject.transform.position;
        EnemyPosition = transform.position;

        if (PlayerPosition.x > EnemyPosition.x)
        {
            EnemyPosition.x = EnemyPosition.x - 0.01f;
        }
        else if (PlayerPosition.x < EnemyPosition.x)
        {
            EnemyPosition.x = EnemyPosition.x - 0.01f;
        }

        if (PlayerPosition.y > EnemyPosition.y)
        {
            EnemyPosition.y = EnemyPosition.y - 0.01f;
        }
        else if (PlayerPosition.y < EnemyPosition.y)
        {
            EnemyPosition.y = EnemyPosition.y - 0.01f;
        }

        EnemyPosition.y = EnemyPosition.y - 0.01f;
        }
    }
