using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform newLocation = null;
    public GameObject space = null;

	public void OnBeginDrag(PointerEventData eventData)
    {
        space = new GameObject();
        space.transform.SetParent(this.transform.parent);
        LayoutElement layout = space.AddComponent<LayoutElement>();
        layout.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        layout.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        layout.flexibleHeight = 0; layout.flexibleWidth = 0;

        space.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        newLocation = this.transform.parent;

        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        int newspace = newLocation.childCount;

        for (int i =0; i < newLocation.childCount; i++)
        {
            if(this.transform.position.x < newLocation.GetChild(i).position.x)
            {
                newspace = i;
                if (space.transform.GetSiblingIndex() < newspace)
                    newspace--;
                break;
            }
        }
        space.transform.SetSiblingIndex(newspace);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(newLocation);
        this.transform.SetSiblingIndex(space.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(space);
    }
}
