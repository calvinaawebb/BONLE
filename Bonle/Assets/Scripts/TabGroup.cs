using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public List<TabButton> backgrounds;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public Sprite backIdle;
    public Sprite backHover;
    public Sprite backActive;
    public TabButton selectedTab;
    public List<GameObject> objectsToSwap;
    //public List<GameObject> backgroundsToSwap;

    // Start is called before the first frame update
    public void Subscribe(TabButton button)
    {
        if (tabButtons == null) 
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
        backgrounds.Add(button.back);
    }

    public void OnTabEnter(TabButton button) 
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab) 
        {
            button.background.sprite = tabHover;
            button.back.background.sprite = backHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button) 
    {
        if (selectedTab != null) 
        {
            selectedTab.Deselect();
        }
        selectedTab = button;
        selectedTab.Select();
        //selectedTab.back.Select();
        ResetTabs();
        button.background.sprite = tabActive;
        button.back.background.sprite = backActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++) 
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else 
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs() 
    {
        foreach(TabButton button in tabButtons) 
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
            foreach (TabButton backg in backgrounds)
            {
                //if (selectedTab != null && button == selectedTab) { continue; }
                backg.background.sprite = backIdle;
            }
        }
    }
}
