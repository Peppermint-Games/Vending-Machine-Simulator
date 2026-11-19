using System.Collections.Generic;
public class ItemDatabase{
  public static itemData newItem(int id){
    itemData newI = new itemData();
    newI.id = id;
    switch(id)
    {
      case 0001:
        newI.itemName = "Bottle of Water";
        newI.itemDescription = "A cool bottle of spring water";
        newI.val = 2;
        break;
    }
    return newI;
  }
}
