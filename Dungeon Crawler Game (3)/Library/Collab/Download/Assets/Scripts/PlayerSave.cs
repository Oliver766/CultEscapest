using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

public class PlayerSave : MonoBehaviour
{
    #region Singleton

    private static PlayerSave _instance;

    public static PlayerSave Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {

            Destroy(this.gameObject);


        }
        else
        {

            _instance = this;
        }


    }



    #endregion



    ////public ItemSlotSaveData mySave;
    //public static string savePath;
    //public MyClass mysave;
    public Inventory container;







    public static void Save( Character character, Inventory container)
    {

        IFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Cult Escapest.json";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedData data = new SavedData(character, container);
      
        formatter.Serialize(stream, data);
        formatter.Serialize(stream, container);

        stream.Close();
       
        //string saveData = JsonUtility.ToJson(mysave, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

     
    }

    public static SavedData LoadData (Character character, Inventory container)
    {
        string path = Application.persistentDataPath + "/Cult Escapest.json";
        FileStream stream = new FileStream(path, FileMode.Open);
        if (File.Exists(path) && stream.Length > 0)
        {

            IFormatter formatter = new BinaryFormatter();
            SavedData data = formatter.Deserialize(stream) as SavedData;
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);
            Debug.Log(stream);
            for(int i = 0; i <  container.Items.Length; i++)
            {
                container.Items[i].UpdateSlot(newContainer.Items[i].ID, newContainer.Items[i].item, newContainer.Items[i].amount);
                Debug.Log(newContainer);

            }


            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found" + path);
            return null;


        }


        //if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
        //    JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), mysave);
        //    file.Close();

       
        //}
    }


    //SaveData data = new SaveData()
    //{

    //    slots = new System.Collections.Generic.List<Inventory>(),
    //    position = character.transform.position,
    //    rotation = character.transform.rotation





}

//[System.Serializable]
//public class MyClass
//{
//    public InventoryObject Container;


 

//    public MyClass(  InventoryObject inventory ,  Character character , Unit playerUnit )
//    {
      


       



//        //for(int i = 0; i< enemie.Count; i++)
//        //{
//        //    if(enemie[i].isDead == true)
//        //    {
//        //        enemie[i] =  null;



//        //    }
//        //    else if( enemie[i].isDead == false)
//        //    {

//        //        GameObject.Instantiate(enemie[i]);


//        //    }


//        //}







    //}











