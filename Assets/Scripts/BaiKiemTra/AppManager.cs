using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public GameObject hienThiThongTin;
    public GameObject themThongTin;
    public GameObject customerPrefab; // Kéo prefab vào đây từ Inspector
    public Transform displayParent; // Kéo transform của đối tượng chứa các prefab sinh ra vào đây
    public CustomerDatabase customerDatabase; // Kéo CustomerDatabase vào đây từ Inspector

    private void Start()
    {
        DisplayCustomerInfo();
    }

    public void BatHienThi()
    {
        themThongTin.SetActive(false);
        hienThiThongTin.SetActive(true);
        DisplayCustomerInfo();
    }

    public void BatThemThongTin()
    {
        themThongTin.SetActive(true);
        hienThiThongTin.SetActive(false);
    }

    void DisplayCustomerInfo()
    {
        // Xóa tất cả các prefab hiện có trước khi sinh ra mới
        foreach (Transform child in displayParent)
        {
            Destroy(child.gameObject);
        }

        // Lấy danh sách khách hàng từ CustomerDatabase
        List<Customers> customersList = customerDatabase.customers;

        // Sinh ra prefab cho mỗi khách hàng trong danh sách
        foreach (Customers customer in customersList)
        {
            // Tạo một instance của prefab
            GameObject customerObject = Instantiate(customerPrefab, displayParent);
            // Cập nhật thông tin khách hàng cho prefab
            CustomerDisplay customerDisplay = customerObject.GetComponent<CustomerDisplay>();
            if (customerDisplay != null)
            {
                customerDisplay.UpdateCustomerInfo(customer);
            }
        }
    }
}
