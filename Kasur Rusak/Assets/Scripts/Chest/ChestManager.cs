using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public List<GameObject> Chest;

    #region Singleton

    private static ChestManager _instance = null;

    public static ChestManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ChestManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: Chest Manager not Found");
                }
            }

            return _instance;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
