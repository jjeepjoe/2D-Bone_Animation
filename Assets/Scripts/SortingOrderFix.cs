using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script makes characters that are made out of parts like our RPG characters 
// NOT overlap when they are on top of each other
//IT ALSO RETURNS WHEN OUT OF GAME MODE.
public class SortingOrderFix : MonoBehaviour {
   
    //STORING THE NAME OF THE OBJECTS NAME AND TRANSFORMS TO BE USED IN SKINNING.
    public Dictionary<string, Transform> AllTransformsByName = new Dictionary<string, Transform>();
    public bool AddToSortingOrder; //AD OR SUBTTACT FROM THE ORDER.
    static int renderOrderOffset = 0; //USED IF MORE THAN ONE SCRIPT IN ACTION > ALL SCRIPTS KNOW THIS VALUE.
    private List<Transform> _allChildren;
    private List<SpriteRenderer> _allSpriteRenderers;
    private int renderOffsetUsedForThisCharacter;
    //PROPERTY
    public List<SpriteRenderer> AllSprites
    {
        get{ return _allSpriteRenderers;}
    }
    //PROPERTY TO MOVE THE CHARACTER IN FRONT OR BEHIND
    public int RendererOffset{ get{ return renderOffsetUsedForThisCharacter; }}
    //DO THE WORK AT START OF LIFE.
    void Awake ()
    {  
        //FILL LIST WITH ALL TRANSFORMS > PASS THAT TO GET SPRITE RENDERERS
        _allChildren = GetAllChildObjects();
        _allSpriteRenderers = GetAllSpriteRenderersFromTransformList(_allChildren);
        //
        if (tag == "Player")
            return;
        //THIS WILL MAKE ROOM FOR OTHER OF THESE SCRIPTS IN ACTION.
        renderOrderOffset += 1000;
        //SET THE OFFSET
        if (AddToSortingOrder)
            renderOffsetUsedForThisCharacter = renderOrderOffset;
        else
            renderOffsetUsedForThisCharacter = -renderOrderOffset;

        ApplyOffset(renderOffsetUsedForThisCharacter);            
    }
    //MOVER THE ORDER
    private void ApplyOffset(int offset)
    {
        foreach (SpriteRenderer sr in _allSpriteRenderers)
        {
            sr.sortingOrder += offset;
        }
    }
    /*
     * THIS IS THE MAIN ENGINE > CONNECTING TO ALL GAME OBJECTS IN THE CHARACTER CONTAINER
     * recursively searches for all child game objects > THIS OPENS ALL CHILDREN OF CHILDREN
     */
    private List<Transform> GetAllChildObjects()
    {
        List<Transform> AllTransforms = new List<Transform>();
        int CountBefore;
        AllTransforms.Add(transform);
        /*
         * STORES THE TRANSFORMS IN A LIST > WILL OPERATE ONCE THEN CHECK CONDITION
         * THIS WILL OPEN THE CHILD OBJECT AND LOOK FOR INTERNAL CHILDREN.
         * FILL THE DICTIONARY WITH OBJECTS
         */
        do
        {
            CountBefore = AllTransforms.Count;
            for(int i = 0; i<AllTransforms.Count; i++)
                foreach(Transform child in AllTransforms[i])
                    if (!AllTransforms.Contains(child))
                    {  
                        if (AllTransformsByName.ContainsKey(child.gameObject.name))
                            Debug.Log(child.gameObject.name);
                        AllTransformsByName.Add(child.gameObject.name, child);
                        AllTransforms.Add(child);
                    }            
        }
        while(AllTransforms.Count != CountBefore);
        return AllTransforms;
    }
    /*
     * THIS WILL TAKE IN THE LIST AND FIND SPRETRENDERS > ADD TO NEW LIST
     * IF OBJECT DOES NOT HAVE SPRITE IGNORE IT.
     */
    private List<SpriteRenderer> GetAllSpriteRenderersFromTransformList(List<Transform> transforms)
    {
        List<SpriteRenderer> spriteRenderersFound = new List<SpriteRenderer>();
        foreach (Transform t in transforms)
        {
            SpriteRenderer sr = t.GetComponent<SpriteRenderer>();
            if (sr != null)
                spriteRenderersFound.Add(sr);
        }
        return spriteRenderersFound;
    } 
}
