using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddCustomerManager : MonoBehaviour
{
    public TMP_InputField customerNameInput;
    public TMP_InputField roomNumberInput;
    public TMP_InputField priceRoomInput;
    public TMP_InputField numberOfStayDaysInput;
    public CustomerDatabase customerDatabase; // Kéo CustomerDatabase vào đây từ Inspector

    // Phương thức gọi khi nhấn nút thêm
    public void AddCustomer()
    {
        // Lấy dữ liệu từ các input fields
        string customerName = customerNameInput.text;
        string roomNumber = roomNumberInput.text;

        // Chuyển đổi giá phòng và số ngày lưu trú từ string sang float
        float priceRoom;
        float numberOfStayDays;

        if (!float.TryParse(priceRoomInput.text, out priceRoom))
        {
            Debug.LogError("Invalid priceRoom value");
            return;
        }

        if (!float.TryParse(numberOfStayDaysInput.text, out numberOfStayDays))
        {
            Debug.LogError("Invalid numberOfStayDays value");
            return;
        }

        // Tạo một đối tượng Customer mới
        Customers newCustomer = new Customers
        {
            customerName = customerName,
            roomNumber = roomNumber,
            priceRoom = priceRoom,
            numberOfStayDays = numberOfStayDays
        };

        // Thêm đối tượng Customer vào CustomerDatabase
        if (customerDatabase != null)
        {
            customerDatabase.customers.Add(newCustomer);
            Debug.Log("Customer added successfully");
        }
        else
        {
            Debug.LogError("CustomerDatabase not assigned");
        }

        // Xóa dữ liệu nhập sau khi thêm (tuỳ chọn)
        ClearInputs();
    }

    // Phương thức để xóa dữ liệu nhập
    private void ClearInputs()
    {
        customerNameInput.text = "";
        roomNumberInput.text = "";
        priceRoomInput.text = "";
        numberOfStayDaysInput.text = "";
    }
}
