using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shapeshifter : MonoBehaviour {

    public OutfitAsset Outfit1;
    public OutfitAsset Outfit2;

    private OutfitApplier applier;

    void Awake ()
    {
        applier = GetComponent<OutfitApplier>();
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (applier.CurrentAsset == Outfit1)
                applier.ApplyLookFromAsset(Outfit2);
            else
                applier.ApplyLookFromAsset(Outfit1);
        }
    }
}
