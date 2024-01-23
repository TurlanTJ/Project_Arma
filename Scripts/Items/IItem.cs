using System.Collections;
using System.Collections.Generic;

public interface IItem
{
    int itemID {get; set;}
    string itemName {get; set;}
    bool isStackable {get; set;}
    int currStack {get; set;}
    int maxStack {get; set;}

    bool Use();
}
