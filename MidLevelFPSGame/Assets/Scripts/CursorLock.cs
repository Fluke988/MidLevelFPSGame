using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    public bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (locked == false)
            {
                Debug.Log("locked");
                Cursor.lockState = CursorLockMode.Locked;
                locked = true;
            }
            else
            {
                Debug.Log("Unlocked");
                Cursor.lockState = CursorLockMode.None;
                locked = false;
            }
        }
    }
}