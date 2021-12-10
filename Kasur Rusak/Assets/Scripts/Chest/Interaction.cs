using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] PuzzleType puzzleType;
    //[SerializeField] Chest chest;
    //public List<GameObject> chest;
    public Animator chestAnimator;
    public GameObject text;
    //public Text puzzleTitle;

    bool Open = false;
    bool isTrigger = false;
    bool isSolved = false;
    bool con = false;

    int counter1 = 0;
    int counter2 = 0;
    int counter3 = 0;
    int counter4 = 0;

    #region Singleton

    private static Interaction _instance = null;

    public static Interaction Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Interaction>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }
    #endregion

    public int Counter1 { get { return counter1; } }
    public int Counter2 { get { return counter2; } }
    public int Counter3 { get { return counter3; } }
    public int Counter4 { get { return counter4; } }

    public int Counter1Up()
    {
        if (counter1 < 9)
            return counter1++;
        else
            return counter1;
    }

    public int Counter2Up()
    {
        if (counter2 < 9)
            return counter2++;
        else
            return counter2;
    }

    public int Counter3Up()
    {
        if (counter3 < 9)
            return counter3++;
        else
            return counter3;
    }

    public int Counter4Up()
    {
        if (counter4 < 9)
            return counter4++;
        else
            return counter4;
    }

    public int Counter1Down()
    {
        if (counter1 > 0)
            return counter1--;
        else
            return counter1;
    }

    public int Counter2Down()
    {
        if (counter2 > 0)
            return counter2--;
        else
            return counter2;
    }

    public int Counter3Down()
    {
        if (counter3 > 0)
            return counter3--;
        else
            return counter3;
    }

    public int Counter4Down()
    {
        if (counter4 > 0)
            return counter4--;
        else
            return counter4;
    }

    private void Start()
    {
        chestAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (isTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                openPuzzle();
                enableFPS(false);
            }
        }    
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            isTrigger = true;
            if (isSolved == false)
                text.SetActive(true);
            else
                text.SetActive(false);
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            isTrigger = false;
            text.SetActive(false);
        }
    }

    private void openPuzzle()
    {
        
        if (con == false)
        {
            PuzzleUI.Instance.Puzzle();
            con = true;
        }
        else
        {
            PuzzleUI.Instance.QuitPuzzle();
            con = false;
        }
    }

    public void CheckPuzzle()
    {
        if (puzzleType == PuzzleType.Puzzle01)
        {
            if (Counter1 == 1 && Counter2 == 3 && Counter3 == 8 && Counter4 == 1)
            {
                Open = !Open;
                chestAnimator.SetBool("Open", Open);
                PuzzleUI.Instance.QuitPuzzle();
                Debug.Log("BENAR");
                enableFPS(true);
            }
            else
            {
                Debug.Log("SALAH");
            } 
        } 
        else if (puzzleType == PuzzleType.Puzzle02)
        {
            if (Counter1 == 3 && Counter2 == 1 && Counter3 == 5 && Counter4 == 7)
            {
                Open = !Open;
                chestAnimator.SetBool("Open", Open);
                PuzzleUI.Instance.QuitPuzzle();
                Debug.Log("BENAR");
                enableFPS(true);
            }
            else
            {
                Debug.Log("SALAH");
            }
        }
    }

    void enableFPS(bool enable)
    {
        GameObject fpsObj = GameObject.Find("FPSController");
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsScript = fpsObj.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

        if (enable)
        {
            //Enable FPS script
            fpsScript.enabled = true;
        }
        else
        {
            //Disable FPS script
            fpsScript.enabled = false;
            //Unlock Mouse and make it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

public enum PuzzleType
{
    Puzzle01,
    Puzzle02,
    Puzzle03
}


