using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    float currentTime = .1f;

    public Text gameName;
    public Text pressAnyKey;

    public Text mapSelect;
    public Text[] maps;

    public GameObject mapSelectBg;
    public GameObject[] currentSelection;
    public GameObject[] selectionPreviews;
    public int selection;

    bool title = true;
    bool menu = false;

    int mapcount = 2;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Application.Quit();
        }
        //if (Input.anyKeyDown && title)
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (title)
            {
                gameName.gameObject.SetActive(false);
                pressAnyKey.gameObject.SetActive(false);
                menu = true;
            }
        }
        if (menu)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                //if (Input.anyKeyDown && Input.GetKeyDown(KeyCode.W) != true && Input.GetKeyDown(KeyCode.A) != true && Input.GetKeyDown(KeyCode.S) != true && Input.GetKeyDown(KeyCode.D) != true && Input.GetKeyDown(KeyCode.LeftArrow) != true && Input.GetKeyDown(KeyCode.RightArrow) != true && Input.GetKeyDown(KeyCode.UpArrow) != true && Input.GetKeyDown(KeyCode.DownArrow) != true)
                if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
                {
                    SceneManager.LoadScene(selection + 1);
                    
                }
            }

            //print(currentTime);
            mapSelect.gameObject.SetActive(true);
            maps[0].gameObject.SetActive(true);
            maps[1].gameObject.SetActive(true);
            maps[2].gameObject.SetActive(true);
            mapSelectBg.SetActive(true);
            switch (selection) {
                case 0:
                    currentSelection[0].SetActive(true);
                    currentSelection[1].SetActive(false);
                    currentSelection[2].SetActive(false);
                    selectionPreviews[0].SetActive(true);
                    selectionPreviews[1].SetActive(false);
                    selectionPreviews[2].SetActive(false);
                    break;
                case 1:
                    currentSelection[0].SetActive(false);
                    currentSelection[1].SetActive(true);
                    currentSelection[2].SetActive(false);
                    selectionPreviews[0].SetActive(false);
                    selectionPreviews[1].SetActive(true);
                    selectionPreviews[2].SetActive(false);
                    break;
                case 2:
                    currentSelection[0].SetActive(false);
                    currentSelection[1].SetActive(false);
                    currentSelection[2].SetActive(true);
                    selectionPreviews[0].SetActive(false);
                    selectionPreviews[1].SetActive(false);
                    selectionPreviews[2].SetActive(true);
                    break;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                selection++;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                selection--;
            }
            if (selection < 0)
            {
                selection = 0;
            }
            if (selection > mapcount)
            {
                selection = mapcount;
            }



        }
    }
}
