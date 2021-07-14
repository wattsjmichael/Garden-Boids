using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class IconManager : MonoBehaviour
{
    [SerializeField] List<GameObject> icons = new List<GameObject>();
    private Icon hoveredIcon;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F));
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;

            hoveredIcon = objectHit.GetComponent("Icon") as Icon;

            if (hoveredIcon != null & hoveredIcon.getHovered() == false & hoveredIcon.getSelected() == false)
            {
                hoveredIcon.startHover();
            }
        } else 
        {
            if (hoveredIcon.getHovered() == true)
            {
                hoveredIcon.stopHover();
            }
        }
    }

    public void resetAllIcons()
    {
        foreach(GameObject iconObject in icons)
        {
            Icon icon = iconObject.GetComponent("Icon") as Icon;
            if (icon.getSelected() == true)
            {
                icon.resetIcon();
            }
        }
    }
}