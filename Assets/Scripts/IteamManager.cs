using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SimpleFileBrowser;  // Sử dụng plugin Simple File Browser

public class IteamManager : MonoBehaviour
{
    public IteamDatabase iteamDatabase;  // Tham chiếu tới database chứa danh sách các Iteam
    public GameObject iteamPrefab;       // Prefab để hiển thị từng Iteam
    public Transform parentTransform;    // Vị trí các prefab sẽ sinh ra (ví dụ: một layout trong Canvas)

    // Tham chiếu đến các InputField và Image component
    public TMP_InputField productNameInput;
    public TMP_InputField productDescriptionInput;
    public Image productImagePreview;

    private Texture2D selectedImageTexture;  // Ảnh được người dùng chọn dưới dạng Texture2D
    private string selectedImagePath;         // Đường dẫn của ảnh

    void Start()
    {
        // Hiển thị các iteam hiện có trong database
        DisplayIteams();
    }

    // Hiển thị các Iteam hiện có trong database
    public void DisplayIteams()
    {
        foreach (var iteam in iteamDatabase.iteams)
        {
            GameObject iteamObject = Instantiate(iteamPrefab, parentTransform);
            IteamDisplay display = iteamObject.GetComponent<IteamDisplay>();
            display.SetupIteam(iteam);
        }
    }

    // Mở Simple File Browser để chọn ảnh
    public void PickImage()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".png", ".jpg", ".jpeg"));
        FileBrowser.SetDefaultFilter(".png");

        // Mở file browser
        FileBrowser.ShowLoadDialog(
            paths =>
            {
                if (paths.Length > 0)
                {
                    selectedImagePath = paths[0];
                    LoadImage(selectedImagePath);  // Lấy đường dẫn của ảnh đầu tiên
                }
            },
            null,
            FileBrowser.PickMode.Files,
            false,
            null,
            "Select Image",
            "Select"
        );
    }

    // Tải ảnh từ đường dẫn và hiển thị ảnh preview
    private void LoadImage(string path)
    {
        selectedImageTexture = new Texture2D(2, 2);
        selectedImageTexture.LoadImage(System.IO.File.ReadAllBytes(path));
        Sprite selectedImageSprite = Sprite.Create(selectedImageTexture, new Rect(0, 0, selectedImageTexture.width, selectedImageTexture.height), new Vector2(0.5f, 0.5f));
        productImagePreview.sprite = selectedImageSprite;  // Hiển thị ảnh đã chọn

        Debug.Log($"Image Loaded: {path}");
        Debug.Log($"Image Size: {selectedImageTexture.width}x{selectedImageTexture.height}");
    }

    // Thêm một Iteam mới vào database
    public void AddNewIteam()
    {
        if (selectedImageTexture != null && !string.IsNullOrEmpty(productNameInput.text) && !string.IsNullOrEmpty(productDescriptionInput.text))
        {
            // Tạo một đối tượng Iteam mới
            Sprite newIteamSprite = Sprite.Create(selectedImageTexture, new Rect(0, 0, selectedImageTexture.width, selectedImageTexture.height), new Vector2(0.5f, 0.5f));

            Iteams newIteam = new Iteams
            {
                productName = productNameInput.text,
                productDescription = productDescriptionInput.text,
                productImage = newIteamSprite  // Gán Sprite mới
            };

            // Thêm vào database
            iteamDatabase.iteams.Add(newIteam);

            // Hiển thị iteam mới
            GameObject iteamObject = Instantiate(iteamPrefab, parentTransform);
            IteamDisplay display = iteamObject.GetComponent<IteamDisplay>();
            display.SetupIteam(newIteam);

            // Debug thông tin của Iteam
            Debug.Log("New Iteam Added:");
            Debug.Log($"Name: {newIteam.productName}");
            Debug.Log($"Description: {newIteam.productDescription}");
            Debug.Log($"Image Size: {newIteam.productImage.texture.width}x{newIteam.productImage.texture.height}");
        }
        else
        {
            Debug.LogWarning("Please fill out all fields and select an image.");
        }
    }
}
