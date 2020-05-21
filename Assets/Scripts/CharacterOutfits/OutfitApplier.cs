using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * WE SET ALL OF THE CONNECTIONS TO THE CHARACTER IN THE SCENE.
 * WE COULD AUTOMATE THIS TO USE A LIST MATCH ANS MAKE THE SETTINGS.
 */
public class OutfitApplier : MonoBehaviour {
    //OUR SCRIPTABLE OBJECT
    public OutfitAsset InitialAsset;
    public bool UseJoints = false;

    [Space(10)]
    [Header("Head")]
    public SpriteRenderer Head;
    public SpriteRenderer Eyebrows;
    public SpriteRenderer Eyes;
    public SpriteRenderer Mouth;

    [Header("Body")]
    public SpriteRenderer TorsoSkin;
    public SpriteRenderer NeckSkin;
    public SpriteRenderer Skirt;

    [Header("Legs")]
    public SpriteRenderer CloserLegUpper;
    public SpriteRenderer CloserLegLower;

    public SpriteRenderer RemoteLegUpper;
    public SpriteRenderer RemoteLegLower;

    [Header("Arms")]
    public SpriteRenderer CloserArm;
    public SpriteRenderer CloserHand;

    public SpriteRenderer RemoteArm;
    public SpriteRenderer RemoteHand;
    //THIS IS THE SECTION FOR DIFFERENT SIZE CHARCTERS
    [Space(10)]
    [Header("Joint Transforms")]
    public Transform TorsoJoint;
    public Transform NeckJoint;
    public Transform CloserShoulderJoint;
    public Transform CloserElbowJoint;
    public Transform RemoteShoulderJoint;
    public Transform RemoteElbowJoint;
    public Transform CloserHipJoint;
    public Transform RemoteHipJoint;
    public Transform CloserKneeJoint;
    public Transform RemoteKneeJoint;
        
    private OutfitAsset currentAsset;
    //PROPERTY FOR IN GAME CHANGES
    public OutfitAsset CurrentAsset
    {
        get{ return currentAsset; }
    }
    //THIS IS THE CHILD INFO OF ALL THE CHILD OBJECTS FOR UNIQUE ITEMS
    private SortingOrderFix DataAboutAllChildren;
    private Dictionary<string, GameObject> UniqueItemsCreated = new Dictionary<string, GameObject>();
    //CONNECTIONS
    void Awake()
    {
        //APPLIES THE CHARACTER CHANGES
        DataAboutAllChildren = GetComponent<SortingOrderFix>();
        if (InitialAsset != null)
            ApplyLookFromAsset(InitialAsset);
    }
    //STAGES THE MODIFICATION ON THE CHARACTER
    public void ApplyLookFromAsset(OutfitAsset asset)
    {
        // save current asset
        currentAsset = asset;
        //IF A COMPLEX RIG
        ApplyLookToFront(asset);
        //WHILE IN GAME CHANGES > FIRST STRIP CURRENT ITEMS
        HideUniqueItems();
        //RE ITEM HIM
        DisplayUniqueItems(asset);
        //RESIZE ACTIONS IF USED.
        if (UseJoints)
            PlaceJointsFromAsset(asset);
    }
    //
    private void PlaceJointsFromAsset(OutfitAsset asset)
    {
        if (TorsoJoint != null)
        {
            TorsoJoint.localPosition = new Vector3(asset.TorsoJoint.LocalPosition.x, asset.TorsoJoint.LocalPosition.y, 0f);
            TorsoJoint.localRotation = Quaternion.Euler(0f, 0f, asset.TorsoJoint.LocalZRotation);
        }

        if (NeckJoint != null)
        {
            NeckJoint.localPosition = new Vector3(asset.NeckJoint.LocalPosition.x, asset.NeckJoint.LocalPosition.y, 0f);
            NeckJoint.localRotation = Quaternion.Euler(0f, 0f, asset.NeckJoint.LocalZRotation);
        }

        if (CloserShoulderJoint != null)
        {
            CloserShoulderJoint.localPosition = new Vector3(asset.CloserShoulderJoint.LocalPosition.x, asset.CloserShoulderJoint.LocalPosition.y, 0f);
            CloserShoulderJoint.localRotation = Quaternion.Euler(0f, 0f, asset.CloserShoulderJoint.LocalZRotation);
        }

        if (CloserElbowJoint != null)
        {
            CloserElbowJoint.localPosition = new Vector3(asset.CloserElbowJoint.LocalPosition.x, asset.CloserElbowJoint.LocalPosition.y, 0f);
            CloserElbowJoint.localRotation = Quaternion.Euler(0f, 0f, asset.CloserElbowJoint.LocalZRotation);
        }

        if (CloserHipJoint != null)
        {
            CloserHipJoint.localPosition = new Vector3(asset.CloserHipJoint.LocalPosition.x, asset.CloserHipJoint.LocalPosition.y, 0f);
            CloserHipJoint.localRotation = Quaternion.Euler(0f, 0f, asset.CloserHipJoint.LocalZRotation);
        }

        if (RemoteHipJoint != null)
        {
            RemoteHipJoint.localPosition = new Vector3(asset.RemoteHipJoint.LocalPosition.x, asset.RemoteHipJoint.LocalPosition.y, 0f);
            RemoteHipJoint.localRotation = Quaternion.Euler(0f, 0f, asset.RemoteHipJoint.LocalZRotation);
        }

        if (RemoteShoulderJoint != null)
        {
            RemoteShoulderJoint.localPosition = new Vector3(asset.RemoteShoulderJoint.LocalPosition.x, asset.RemoteShoulderJoint.LocalPosition.y, 0f);
            RemoteShoulderJoint.localRotation = Quaternion.Euler(0f, 0f, asset.RemoteShoulderJoint.LocalZRotation);
        }

        if (RemoteElbowJoint != null)
        {
            //Debug.Log("Moving Remote Elbow Joint");
            RemoteElbowJoint.localPosition = new Vector3(asset.RemoteElbowJoint.LocalPosition.x, asset.RemoteElbowJoint.LocalPosition.y, 0f);
            RemoteElbowJoint.localRotation = Quaternion.Euler(0f, 0f, asset.RemoteElbowJoint.LocalZRotation);
        }

        if (CloserHipJoint != null)
        {
            CloserHipJoint.localPosition = new Vector3(asset.CloserHipJoint.LocalPosition.x, asset.CloserHipJoint.LocalPosition.y, 0f);
            CloserHipJoint.localRotation = Quaternion.Euler(0f, 0f, asset.CloserHipJoint.LocalZRotation);
        }

        if (RemoteHipJoint != null)
        {
            RemoteHipJoint.localPosition = new Vector3(asset.RemoteHipJoint.LocalPosition.x, asset.RemoteHipJoint.LocalPosition.y, 0f);
            RemoteHipJoint.localRotation = Quaternion.Euler(0f, 0f, asset.RemoteHipJoint.LocalZRotation);
        }

        if (CloserKneeJoint != null)
        {
            CloserHipJoint.localPosition = new Vector3(asset.CloserKneeJoint.LocalPosition.x, asset.CloserKneeJoint.LocalPosition.y, 0f);
            CloserHipJoint.localRotation = Quaternion.Euler(0f, 0f, asset.CloserKneeJoint.LocalZRotation);
        }

        if (RemoteKneeJoint != null)
        {
            RemoteHipJoint.localPosition = new Vector3(asset.RemoteKneeJoint.LocalPosition.x, asset.RemoteKneeJoint.LocalPosition.y, 0f);
            RemoteHipJoint.localRotation = Quaternion.Euler(0f, 0f, asset.RemoteKneeJoint.LocalZRotation);
        }

    }

    private void HideUniqueItems()
    {
        foreach (KeyValuePair<string, GameObject> pair in UniqueItemsCreated)
        {
            pair.Value.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void DisplayUniqueItems(OutfitAsset asset)
    {
        if (asset.UniqueItems != null && asset.UniqueItems.Length > 0)
        {
            foreach (UniqueOutfitItem uoi in asset.UniqueItems)
            {
                Debug.Log(uoi.Name);
                GameObject newItem = new GameObject();
                //CHECKS TO SEE IF ON ALREADY
                if (UniqueItemsCreated.ContainsKey(uoi.Name))
                {
                    UniqueItemsCreated[uoi.Name].GetComponent<SpriteRenderer>().enabled = true;
                    Destroy(newItem);
                }
                else
                {
                   ///////GameObject tem_GO = Instantiate()
                    newItem.transform.SetParent(DataAboutAllChildren.AllTransformsByName[uoi.ChildOf]);
                    //TROUBLE ***********
                    Debug.Log("HERE to ADD TO : " + newItem.name);
                    SpriteRenderer sr = newItem.AddComponent<SpriteRenderer>();
                    sr.sortingLayerName = "Player";
                    sr.sortingOrder = uoi.SortingOrder + DataAboutAllChildren.RendererOffset;
                    sr.sprite = uoi.Picture;

                    // Add this new SpriteRenderer to a list of all SRs in DataAboutAllChildren
                    DataAboutAllChildren.AllSprites.Add(sr);

                    newItem.name = uoi.Name;
                    newItem.transform.localPosition = new Vector3(uoi.LocalPosition.x, uoi.LocalPosition.y, 0f);
                    newItem.transform.localRotation = Quaternion.Euler(0f, 0f, uoi.LocalZRotation);
                    newItem.transform.localScale = new Vector3(uoi.LocalScale.x, uoi.LocalScale.y, 1f);

                    UniqueItemsCreated.Add(uoi.Name, newItem);
                }            
            }
        }
    }
    /*
     * THIS MOVES DOWN THRU EACH BODY PARTS > LOOKING AT EACH OUTFIT
     * THEN MAKE SURE THE RENDERER IS NOT NLL
     */
    private void ApplyLookToFront(OutfitAsset asset)
    {
        // for each info in the asset, apply it to the cahracter
        if (asset.Head != null)
        {
            Head.sprite = asset.Head;
            Head.enabled = true;
        }
        else
            Head.enabled = false;

        if (asset.NeckSkin != null)
        {
            NeckSkin.sprite = asset.NeckSkin;
            NeckSkin.enabled = true;
        }
        else
            NeckSkin.enabled = false;

        if (asset.Eyebrows != null)
        {
            Eyebrows.sprite = asset.Eyebrows;
            Eyebrows.enabled = true;
        }
        else
            Eyebrows.enabled = false;

        if (asset.Eyes != null)
        {
            Eyes.sprite = asset.Eyes;
            Eyes.enabled = true;
        }
        else
            Eyes.enabled = false;

        if (asset.Mouth != null)
        {
            Mouth.sprite = asset.Mouth;
            Mouth.enabled = true;
        }
        else
            Mouth.enabled = false;        

        if (asset.CloserArm != null)
        {
            CloserArm.sprite = asset.CloserArm;
            CloserArm.enabled = true;
        }
        else
            CloserArm.enabled = false;
      
        if (asset.CloserHand != null)
        {
            CloserHand.sprite = asset.CloserHand;
            CloserHand.enabled = true;
        }
        else
            CloserHand.enabled = false;

        if (asset.CloserLegLower != null)
        {
            CloserLegLower.sprite = asset.CloserLegLower;
            CloserLegLower.enabled = true;
        }
        else
            CloserLegLower.enabled = false;

        if (asset.CloserLegUpper != null)
        {
            CloserLegUpper.sprite = asset.CloserLegUpper;
            CloserLegUpper.enabled = true;
        }
        else
            CloserLegUpper.enabled = false;

        if (asset.RemoteArm != null)
        {
            RemoteArm.sprite = asset.RemoteArm;
            RemoteArm.enabled = true;
        }
        else
            RemoteArm.enabled = false;

        if (asset.RemoteHand != null)
        {
            RemoteHand.sprite = asset.RemoteHand;
            RemoteHand.enabled = true;
        }
        else
            RemoteHand.enabled = false;

        if (asset.RemoteLegLower != null)
        {
            RemoteLegLower.sprite = asset.RemoteLegLower;
            RemoteLegLower.enabled = true;
        }
        else
            RemoteLegLower.enabled = false;

        if (asset.RemoteLegUpper != null)
        {
            RemoteLegUpper.sprite = asset.RemoteLegUpper;
            RemoteLegUpper.enabled = true;
        }
        else
            RemoteLegUpper.enabled = false;

        if (asset.Skirt != null)
        {
            Debug.Log("SKIRT");
            Skirt.sprite = asset.Skirt;
            Skirt.enabled = true;
        }
        else
            Skirt.enabled = false;

        if (asset.TorsoSkin != null)
        {
            TorsoSkin.sprite = asset.TorsoSkin;
            TorsoSkin.enabled = true;
        }
        else
            TorsoSkin.enabled = false;
    }

}
