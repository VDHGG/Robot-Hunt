# Robot-Hunt

# Robot-Hunt 🤖🎮

**Robot-Hunt** là một dự án game được xây dựng nhằm mục đích học tập và thực hành lập trình game, tập trung vào:
- Điều khiển nhân vật
- Cơ chế săn robot 
- Quản lý đối tượng trong game
- Tổ chức project và code theo chuẩn Unity

Dự án đóng vai trò là nền tảng để mở rộng thành một game hành động hoàn chỉnh hơn trong tương lai.

---

## 🎯 Mục tiêu dự án

- Làm quen với quy trình phát triển game bằng Unity
- Áp dụng C# để xử lý logic game
- Hiểu cách tổ chức code và tài nguyên trong Unity
- Rèn luyện tư duy thiết kế gameplay cơ bản

---

## 🕹️ Gameplay tổng quan

- Người chơi điều khiển nhân vật chính
- Di chuyển trong bản đồ và săn các robot
- Tấn công kẻ địch để ghi điểm hoặc hoàn thành mục tiêu
- Tránh đòn tấn công từ robot 

---

## 🎮 Điều khiển cơ bản

- **Di chuyển:** W / A / S / D  
- **Tấn công:** Chuột trái hoặc phím được gán sẵn  

---

## 🚀 Các tính năng hiện có

- Điều khiển nhân vật mượt
- Robot kẻ địch xuất hiện trong scene
- Cơ chế tấn công cơ bản
- Xử lý va chạm (collision)
- Game loop đơn giản, dễ hiểu

---

## 📂 Giải thích chi tiết cấu trúc code

### 🔹 Assets/
Chứa toàn bộ tài nguyên của game.

---

### 📁 Scripts/
Chứa các file C# xử lý logic game.  
Các nhóm script chính thường bao gồm:

#### 🧍 Player Scripts
- Xử lý di chuyển nhân vật
- Nhận input từ bàn phím/chuột
- Thực hiện hành động tấn công
- Kết nối với Animator

Ví dụ chức năng:
- Đọc input (`Input.GetAxis`, `Input.GetKey`)
- Điều khiển `Rigidbody` hoặc `CharacterController`
- Gọi animation Attack / Move

---

#### 🤖 Enemy (Robot) Scripts
- Điều khiển hành vi robot
- Phát hiện người chơi
- Thực hiện tấn công hoặc di chuyển

Có thể bao gồm:
- Robot AI đơn giản
- Kiểm tra khoảng cách với player
- Xử lý bị tiêu diệt

---

#### ⚙️ Game Manager Scripts
- Quản lý trạng thái game
- Bắt đầu / kết thúc game
- Quản lý điểm số hoặc số lượng robot

---

### 📁 Scenes/
- Mỗi scene đại diện cho một màn chơi hoặc trạng thái game
- Ví dụ:
  - `MainScene.unity` – Scene chính để chơi

---

### 📁 Prefabs/
- Lưu trữ các đối tượng tái sử dụng
- Ví dụ:
  - Player prefab
  - Robot prefab
  - Đạn, hiệu ứng

Prefab giúp:
- Dễ chỉnh sửa hàng loạt
- Giảm lỗi khi thay đổi object

---

### 📁 Animations/
- Chứa animation cho player và robot
- Sử dụng **Animator Controller**
- Các state phổ biến:
  - Idle
  - Move
  - Attack
  - Death

---

### 📁 Audio/
- Chứa âm thanh game
- Bao gồm:
  - Sound effect
  - Nhạc nền

---

## ▶️ Hướng dẫn chạy project

1. Cài **Unity Hub**
2. Cài Unity phiên bản phù hợp (khuyến nghị Unity 2020+)
3. Clone project:
   ```bash
   git clone https://github.com/VDHGG/Robot-Hunt.git
Mở Unity Hub → Open Project

Chọn thư mục Robot-Hunt

Mở scene chính trong thư mục Scenes

Nhấn Play để chạy game

