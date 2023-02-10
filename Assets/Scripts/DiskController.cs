using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskController : BaseBehaviour, IDiskPropertyManager
{
    public float DiskSize;
    public Color DiskColor;
    public GameObject DiskSprite;

    void Start()
    {
        var _diskSprite_SpriteRenderer = DiskSprite.GetComponent<SpriteRenderer>();

        DiskColor.a = 1f;
        _diskSprite_SpriteRenderer.color = DiskColor;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = GetScaleFromDiskSize;
    }

    private Vector3 GetScaleFromDiskSize => new Vector3((DiskSize * 3) + 10f, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

    public float GetDiskSize() => DiskSize;
    public void SetDiskSize(float size) => DiskSize = size;
}
