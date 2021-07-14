using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    [SerializeField] private IconManager iconManager;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material selectedMaterial;

    private bool selected;
    private bool hovered;
    private IEnumerator coroutine;

    public void setSelected(bool select)
    {
        selected = select;
    }

    public bool getSelected()
    {
        return selected;
    }

    public bool getHovered()
    {
        return hovered;
    }

    public void startHover()
    {
        hovered = true;
        coroutine = Hover();
        StartCoroutine(coroutine);
    }

    public void stopHover()
    {
        hovered = false;
        StopCoroutine(coroutine);
        resetIcon();
    }

    public void resetIcon()
    {
        hovered = false;
        selected = false;
        transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
        // change to default color
        var selectionRender = transform.GetComponent<Renderer>();
        if (selectionRender != null)
        {
            selectionRender.material = defaultMaterial;
        }
    }

    private IEnumerator Hover()
    {
        // change to highlight color
        var selectionRender = transform.GetComponent<Renderer>();
        if (selectionRender != null)
        {
            selectionRender.material = highlightMaterial;
        }

        // animate scale up
        float elapsedTime = 0;
        Vector3 startScale = new Vector3(0.015f, 0.015f, 0.015f);
        Vector3 targetScale = new Vector3(0.02f, 0.02f, 0.02f);
        
        transform.localScale = startScale;
        float timeTakes = 0.3f;    // animation will take one second
        
        while (elapsedTime < timeTakes)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, (elapsedTime / timeTakes));
        
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.7f);

        // change to selected color
        if (selectionRender != null)
        {
            selectionRender.material = selectedMaterial;
        }
        

        iconManager.resetAllIcons();
        selected = true;
        hovered = false;
    }
}