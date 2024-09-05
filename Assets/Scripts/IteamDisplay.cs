using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IteamDisplay : MonoBehaviour
{
    // Tham chiếu tới các component của prefab
    public Image productImage;
    public TextMeshProUGUI productNameText;
    public TextMeshProUGUI productDescriptionText;

    // Hàm để thiết lập thông tin Iteam
    public void SetupIteam(Iteams iteam)
    {
        productImage.sprite = iteam.productImage;  // Gán hình ảnh
        productNameText.text = iteam.productName;  // Gán tên sản phẩm
        productDescriptionText.text = iteam.productDescription;  // Gán mô tả sản phẩm
    }
}
