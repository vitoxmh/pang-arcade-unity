using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static ItemManager im;

    public GameObject[] item;


    private void Awake()
    {
         

        if (im == null)
        {
            im = this;
           
        }
        else if (im != null)
        {
            Destroy(gameObject);
        }

        
    }

    
    public void createItem(string Getitem, Transform positionObject)
    {

        switch (Getitem)
        {

           case "Arrow":
                Instantiate(item[0], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Hook":
                Instantiate(item[1], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Gun":
                Instantiate(item[2], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Shield":
                Instantiate(item[3], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Clock":
                Instantiate(item[4], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "SandClock":
                Instantiate(item[5], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Dynamite":
                Instantiate(item[6], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break;
           case "Life":
                Instantiate(item[7], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
                break;
           default:
                Instantiate(item[0], new Vector3(positionObject.position.x, positionObject.position.y, 1f), Quaternion.identity);
           break; 

        }

    }



    public void createItemRandom(Transform positionObject)
    {

        int combo = ManagerScore.ms.combo;

        int randomInt;

        if (combo >= 0 && combo <= 7)
        {
            randomInt = Random.Range(0, 7);
        }
        else
        {
            randomInt = Random.Range(0, 8);
        }

        switch (randomInt)
        {
            case 0:
                createItem("Dynamite", positionObject);
                break;
            case 1:
                createItem("Shield", positionObject);
                break;
            case 2:
                createItem("Hook", positionObject);
                break;
            case 3:
                createItem("Arrow", positionObject);
                break;
            case 4:
                createItem("Clock", positionObject);
                break;
            case 5:
                createItem("SandClock", positionObject);
                break;
            case 6:
                createItem("Gun", positionObject);
                break;
            case 7:
                createItem("Life", positionObject);
                break;
        }

    }

}
