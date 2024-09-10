using UnityEngine;
using UnityEngine.EventSystems;

public class TestUI : UIBehaviour {


    protected override void OnRectTransformDimensionsChange() {
        Debug.Log("Size Changed");
    }

}
