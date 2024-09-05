using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    public GameObject hienthi;
    public GameObject themSanPham;

    public void ClickHienthi()
    {
        hienthi.SetActive(true);
        themSanPham.SetActive(false);
}
    public void Clickthem()
    {
        hienthi.SetActive(false);
        themSanPham.SetActive(true);
    }
}
