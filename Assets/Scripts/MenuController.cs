using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text gameName;
    public Text pressAnyKey;

    public Text mapSelect;
    public Text map1;
    public Text map2;
    public Text map3;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && title)
        {
            gameName.gameObject.SetActive(false);
            pressAnyKey.gameObject.SetActive(false);
            menu = true;
        }
        if (menu)
        {
            mapSelect.gameObject.SetActive(true);
            map1.gameObject.SetActive(true);
            map2.gameObject.SetActive(true);
            map3.gameObject.SetActive(true);
            mapSelectBg.SetActive(true);
            switch (selection) {
                case 0:
                    currentSelection[0].SetActive(true);
                    currentSelection[1].SetActive(false);
                    currentSelection[2].SetActive(false);
                    selectionPreviews[0].SetActive(true);
                    break;
                case 1:
                    currentSelection[0].SetActive(false);
                    currentSelection[1].SetActive(true);
                    currentSelection[2].SetActive(false);
                    selectionPreviews[0].SetActive(false);
                    break;
                case 2:
                    currentSelection[0].SetActive(false);
                    currentSelection[1].SetActive(false);
                    currentSelection[2].SetActive(true);
                    selectionPreviews[0].SetActive(false);
                    break;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                selection++;
            }
            if (Input.GetKeyDown(KeyCode.W))
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
