using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusViewer : MonoBehaviour
{
    [SerializeField] List<SMEquipImage> equipImages;

    private void Reset()
    {
        equipImages = new List<SMEquipImage>();
        SMEquipImage[] images = GetComponentsInChildren<SMEquipImage>();
        for(int index = 0; index < images.Length; index++) {
            equipImages.Add(images[index]);
            images[index].Index = index;
        }
    }
}
