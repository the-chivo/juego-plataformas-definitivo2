using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsLists : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<MovementStatus>  statList;
    int listNumber;
    public MovementStatus playerMode;
    void Start()
    {
        playerMode = statList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(listNumber >= statList.Count)
            {
                listNumber = 0;
            }
            playerMode = statList[listNumber];
            listNumber += 1;
        }
    }
}
