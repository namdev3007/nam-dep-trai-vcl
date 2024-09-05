using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorkManager : MonoBehaviour
{
    // Tham chiếu tới InputField và TextMeshPro
    public TMP_InputField inputField;
    public TMP_Text displayText;

    // Tham chiếu tới WorkDatabase ScriptableObject
    public WorkDatabase workDatabase;

    // Hàm thêm dữ liệu vào WorkDatabase
    public void AddWork()
    {
        string workName = inputField.text;

        // Kiểm tra nếu không trống
        if (!string.IsNullOrEmpty(workName))
        {
            Works newWork = new Works { workName = workName };
            workDatabase.works.Add(newWork);
            inputField.text = ""; // Reset InputField sau khi thêm
            UpdateDisplay(); // Cập nhật hiển thị
        }
    }

    // Hàm cập nhật hiển thị danh sách các thành phần trong WorkDatabase
    private void UpdateDisplay()
    {
        displayText.text = ""; // Xóa nội dung hiện tại
        foreach (Works work in workDatabase.works)
        {
            displayText.text += work.workName + "\n"; // Hiển thị tên từng công việc
        }
    }
}
