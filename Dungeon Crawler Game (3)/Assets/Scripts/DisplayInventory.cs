using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem(); // mouse item function

    public GameObject inventoryPrefab; // reference to inventory slot prefab
    public InventoryObject inventory; // reference to inventory object
    public int X_START; // sets x value
    public int Y_START; // sets y value
    public int X_SPACE_BETWEEN_ITEM; // sets x value between slots
    public int NUMBER_OF_COLUMN; // sets number of slots
    public int Y_SPACE_BETWEEN_ITEMS; // sets y value between slots
    public Unit playerunit; // gest reference to player unit
    public GameObject pHud; // gets player hud object
    public BattleHud playerHud; // gest player hud reference
    public int maxh = 50; // sets max heal to 50
    public int minh = 0; // sets min heal to 0
    public Image hitPlayer; // gets reference to heal image
    public GameObject text; // text object

    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>(); // creates new list of slots
    void Start()
    {
        
        CreateSlots(); // creates slots
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();

        if (hitPlayer != null) // hit screen function
        {

            if (hitPlayer.GetComponent<Image>().color.a > 0) // gets image component
            {

                var color = hitPlayer.GetComponent<Image>().color;// gets image component

                color.a -= 0.01f; // screen flashes

                hitPlayer.GetComponent<Image>().color = color;// gets image component

            }

        }
    }
    public void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>(); // itesm displayed equall  new dictionary
        for (int i = 0; i < inventory.inventory.Items.Length; i++) // counts through inventory items
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform); // instantiates item slots
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i); // sets position of item slots

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); }); // on pointer enter event action
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); }); // on pointer exit event action
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); }); // begindrag event action
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });// end drag event action
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); }); // drag event action


            itemsDisplayed.Add(obj, inventory.inventory.Items[i]); // adds items to display
        }
    }
    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed) // for each item slot in itemdisplayed
        {
            if (_slot.Value.ID >= 0) // if slot.value .id is more than equal to 0
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].uiDisplay; // gets child pf image and displays it in slot
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1); // sets hover and press colour of slot
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0"); // sets amount number in slot
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null; // slot has nothing in 
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0); // button does not show any color
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = ""; // there is no amount showing
            }
        }
    }
    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>(); // gets component of event triger
        var eventTrigger = new EventTrigger.Entry(); // creats new event
        eventTrigger.eventID = type; // gets the event id
        eventTrigger.callback.AddListener(action); // adds call back. add listener(action) to event trigger
        trigger.triggers.Add(eventTrigger); // add event trigger to event
    }

    public void OnEnter(GameObject obj)
    {
        mouseItem.hoverObj = obj; //  mouseitem.hoverobj equals object
        if (itemsDisplayed.ContainsKey(obj)) // check is item displayed contains keys(object)
            mouseItem.hoverItem = itemsDisplayed[obj]; // mouse item.hover item =  itemdispayed(object)
       


    }


    public IEnumerator TextT()
    {

        text.SetActive(true);// sets object true

        yield return new WaitForSeconds(1); // waits 3 seconds
        text.SetActive(false);// sets object false

    }


    public void OnExit(GameObject obj)
    {

       

        mouseItem.hoverObj = null; // movve hovering object is null
        mouseItem.hoverItem = null; // mouse item. hover item  is null
    }
    public void OnDragStart(GameObject obj) // when player starts to drag th object
    {
        var mouseObject = new GameObject(); // mouse object equals new object
        var rt = mouseObject.AddComponent<RectTransform>(); // get recttranform component of mouse object
        rt.sizeDelta = new Vector2(50, 50); // set the size of object 
        mouseObject.transform.SetParent(transform.parent); // set parent of mouse object
        if (itemsDisplayed[obj].ID >= 0) // if item displayed [obj]. id is more than equal to 0
        {
            var img = mouseObject.AddComponent<Image>(); // add image component to mouse obejct
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay; // display sprite of picked up object
            img.raycastTarget = false; // ray cast equall 0
        }
        mouseItem.obj = mouseObject;//  mouseitem.hoverobj equals object
        mouseItem.item = itemsDisplayed[obj];// mouse item.hover item =  itemdispayed(object)
    }
    public void OnDragEnd(GameObject obj)
    {
        
        if (mouseItem.hoverObj) // if mouse item. hover object
        {
            inventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[mouseItem.hoverObj]); // move displayed item

          
        }
        else
        {
            int playerhealth = Random.Range(maxh, minh); // find a random range value
            playerHud.SetHP(playerunit.currentHP); // set hp
            StartCoroutine(TextT());
            playerunit.Heal(20 + playerhealth); // had player health to heal
            Debug.Log("up health");
            inventory.RemoveItem(itemsDisplayed[obj].item); // remove item from inventory
            gotHurt(); // regen screen appears
          


        }

        
        Destroy(mouseItem.obj); // destroy mouse object
        mouseItem.item = null; // mouse item equalls null
    }
    public void OnDrag(GameObject obj)
    {
        if (mouseItem.obj != null) // if mouse obj does not equal null
            mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition; // get rect transform component and mouse input
    }


    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f); // get positio  of slot when instantiated
    }


  

    public void gotHurt()
    {

        var color = hitPlayer.GetComponent<Image>().color; ;// gets image component of regen image
        color.a = 0.8f;//  colour equals 0.08f

        hitPlayer.GetComponent<Image>().color = color;// regen image component image . color equals the color

    }

}
public class MouseItem
{
    public GameObject obj; // gets object
    public InventorySlot item; // gets inventory slot item
    public InventorySlot hoverItem; //get ivnventory slot hover item
    public GameObject hoverObj; // gets hover object


}