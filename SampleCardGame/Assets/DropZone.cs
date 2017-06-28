using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DropZone : MonoBehaviour, IDropHandler{

    public int amount = 0;

    public void OnDrop(PointerEventData eventData)
    {
        Drag drag = eventData.pointerDrag.GetComponent<Drag>();
        if(drag != null)
        {
            drag.newLocation = this.transform;
        }

        drag.transform.SetParent(drag.newLocation);
        drag.transform.SetSiblingIndex(0);

        NumberLeft.totalNumber -= CardNumber.number; 

        Destroy(drag.space);
        Destroy(drag);

    }

}
