using UnityEngine;
using TMPro;

public class CustomerDisplay : MonoBehaviour
{
    public TextMeshProUGUI customerNameText;
    public TextMeshProUGUI roomNumberText;
    public TextMeshProUGUI totalPriceText;

    // Cập nhật thông tin khách hàng
    public void UpdateCustomerInfo(Customers customer)
    {
        // Cập nhật tên khách hàng
        customerNameText.text = customer.customerName;

        // Cập nhật số phòng
        roomNumberText.text = "Room: " + customer.roomNumber;

        // Tính thành tiền và cập nhật
        float totalPrice = customer.priceRoom * customer.numberOfStayDays;
        totalPriceText.text = "Total Price: " + totalPrice.ToString("C2");
    }
}
