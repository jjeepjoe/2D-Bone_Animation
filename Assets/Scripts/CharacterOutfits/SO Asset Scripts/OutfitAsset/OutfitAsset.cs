using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * THESE ARE ADDITIONAL ITEMS WE CAN ATTACH TO THE CHARACTER
 * WE FILL OUT THE DATA > CHILD OF NEEDS TO MATCH THE GAME OBJECT
 * TO ATTACH TO. > WE CAN SET THE POSITION AND SCALE > SORT ORDER TOO
 */
[System.Serializable]
public class UniqueOutfitItem
{
    public string Name;
    public Sprite Picture;
    public string ChildOf = "Torso";
    public Vector2 LocalPosition;
    public float LocalZRotation = 0f;
    public Vector2 LocalScale;
    public int SortingOrder = 0;
}
/*
 * IF WE WANT TO USE A SINGLE ANIMATOR WITH DIFFERENT SIZES >
 * TO USE THE SAME OUTFITS > ANIMATIONS >
 */
[System.Serializable]
public class JointInfo
{
    public Vector2 LocalPosition;
    public float LocalZRotation = 0f;
}
/*
 * OUTFIT ASSET STORE THE SPRITE DATA COLLECTION.
 * UNITY INSPECTOR ATTRIBUTES > THIS CAN HOLD EACH CHARACTERS SKILLS, CLOTHING
 * THE PUBLIC FIELDS WILL ALLOW STORAGE IN
 */
public class OutfitAsset : ScriptableObject 
{
    // this object will hold the info about the most general card
    [Header("General info")]
    [TextArea(2,3)]
    public string Description;  // Description for spell or character

    [Space(10)]
    [Header("Head")]
    public Sprite Head;
    public Sprite Eyebrows;
    public Sprite Eyes;
    public Sprite Mouth;

    [Header("Body")]
    public Sprite TorsoSkin;
    public Sprite NeckSkin;
    public Sprite Skirt;

    [Header("Legs")]
    public Sprite CloserLegUpper;
    public Sprite CloserLegLower;

    public Sprite RemoteLegUpper;
    public Sprite RemoteLegLower;

    [Header("Arms")]
    public Sprite CloserArm;
    public Sprite CloserHand;

    public Sprite RemoteArm;
    public Sprite RemoteHand;

    //ANY EXTRA ITEMS WE CAN ATTACH TO THE CHARACTER
    [Header("Unique Items For This Character")]
    public UniqueOutfitItem[] UniqueItems;
    //THIS IS USED FOR OTHER SIZE CHARACTER COPIES WITH DIFFERENT
    //WIDTHS.
    [Header("Joint Information")]
    public JointInfo TorsoJoint;
    public JointInfo NeckJoint;
    public JointInfo CloserShoulderJoint;
    public JointInfo CloserElbowJoint;
    public JointInfo RemoteShoulderJoint;
    public JointInfo RemoteElbowJoint;
    public JointInfo CloserHipJoint;
    public JointInfo RemoteHipJoint;
    public JointInfo CloserKneeJoint;
    public JointInfo RemoteKneeJoint;
}
