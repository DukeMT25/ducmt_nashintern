# ducmt_nashintern
# Fred Perry

Là một thường hiệu thời trang đến từ Anh quốc. Fred Perry là nỗi tiếng với những mẫu áo cổ điển, đẳng cấp. Những sản phẩm của Fred Perry mang theo di sản của mình và cải tiến thêm sau mỗi đời. 
Slogan nối tiếng của hãng với dòng áo G3636 là "Luôn luôn khác biệt, luôn luôn giống nhau". 

Trang web quản lý hãng thời tran Fred Perry gồm những chức năng nổi bật sau:

- Thêm sửa xóa (CRUD) : sản phẩm, category, account.
- sản phẩm (product) và category là mối quan hệ nhiều nhiều được liên kết qua bảng productcategory.
- Được phép chọn nhiều category cho cùng một sản phẩn khi tạo mới hoặc edit
- Đặc biệt lúc xóa category sẽ có 2 chế độ. Kiểm tra xem cate đó có liên kết với sản phầm nào không, nếu không thì xóa an toàn. Còn nếu như có liên kết, người quản lí sẽ có lựa chọn 1 trong những category khác để thay thế category hiện tại và xóa nó. Những sản phẩm có liên kết với category mục tiêu sẽ đổi đúng cate đấy với cate được chọn mới, những cate liên kết sẵn vẫn sẽ được giữ nguyên. 
- Quản lí có thể tìm sản phẩm theo tên, hoặc code. Tìm category theo tên. Tìm người dùng theo username hoặc email.
- Web đã được áp dụng những kiến thức cơ bản đã được học.
