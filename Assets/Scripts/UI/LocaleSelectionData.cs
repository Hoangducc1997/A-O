using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocaleSelectionData
{
    public bool active;
    public int selectedLocaleID;

    public LocaleSelectionData(bool active, int selectedLocaleID)
    {
        this.active = active;
        this.selectedLocaleID = selectedLocaleID;
    }
}
