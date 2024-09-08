use master
go

drop database ToyShop
go

-- create database ToyShop
create database ToyShop
go

use ToyShop
go

-- create table categories
create table Category
(
	Id int primary key  identity(1,1),
	CatName nvarchar(50) not null
)
go

-- create table Product
create table Product
(
	ProId int identity, --ma sp
	ProName nvarchar(200) not null, -- ten sp
	ProPrice decimal (18,3), --gia sp
	ProImage nvarchar(100), -- anh sp
	Discount int, --giam gia --sotiendagiam
	ViewSee int, --luotxem
	material nvarchar(50), --chatlieu
	ship nvarchar(100), --so ngay giao hang
	ProWeight nvarchar(50), -- cannang
	CatId int
	Primary key(ProId),
	Foreign	Key(CatId) References Category(Id)
)
go


-- create table blog
create table Blog
(
	BlogId int primary key not null , --ma bai viet
	BlogName nvarchar(300) not null, --ten bai viet
	BlogDes nvarchar(2000) , --mota
	BlogImages nvarchar(100), --anhbaiviet
	BlogImagesDes nvarchar(100), --anhbiabaiviet
	BlogDate datetime, --ngaydang
	AdminId int
	foreign key(AdminId) References AdminStrator(id) on update cascade 
)
go

--create table admin
create table Adminstrator
(
	id int primary key  ,
	name nvarchar(100),
	username nvarchar(100),
	pass nvarchar(100)
)
go

--create table nguoidung

create table NguoiDung
(
	id int primary key identity,
	name nvarchar(100),
	username nvarchar(100),
	email nvarchar(100),
	pass nvarchar(100),
	address nvarchar(100),
	phone varchar(50),
	birthday datetime
)
go


--create table ctdonhang
Create Table	ChiTietDatHang
(
	id	Int,
	ProId	Int,
	Number	Int	Check(Number>0),
	Price Decimal(18,0)	Check(Price>=0),
	Primary Key(id,ProId),
	Foreign	Key(id)	References	Orders(id),
	Foreign Key(ProId)	References	Product(ProId)
)
go

--create table dathang
create table Orders
(
	id	int primary key ,
	OrderDate	DateTime,
	NgayGiao	DateTime,
	DaThanhToan	Bit,
	TinhTrangGiaoHang	Bit,
	UserId	int
	Constraint	Fk_NguoiDung Foreign Key(UserId) references Nguoidung(id)
)
Go

--insert table category
Insert into Category values (N'Mô Hình')
Insert into Category values (N'Búp Bê')
Insert into Category values (N'Trí Tuệ')
Insert into Category values (N'Thẻ Bài')
Insert into Category values (N'Robot')
Insert into Category values (N'Xe Điều Khiển')
go

-- insert to table Product 
Insert into Product values(N'Hộp Thẻ Bài Yu-Gi-Oh Saga Of Blue Eye',349.000,'/Images/Board_Games/bg1.jpg',0,0,N'giấy',N'5 Ngày',N'300g',4)
Insert into Product values(N'Hộp Thẻ Bài Yugioh Legendary Deck',1499.000 ,'/Images/Board_Games/bg2.jpg',400.000,0,N'giấy',N'5 Ngày',N'300g',4)
Insert into Product values(N'Hộp Thẻ Bài Yugioh Shining Victories Special Edition',799.000 ,'/Images/Board_Games/bg3.jpg',141.000,0,N'giấy',N'5 Ngày',N'300g',4)
Insert into Product values(N'Thẻ Bài Yugioh Ignition Assault',82.250,'/Images/Board_Games/bg4.jpg',0,0,N'giấy',N'5 Ngày',N'300g',4)
Insert into Product values(N'Búp bê khớp áo cam đi xe đạp',99.000,'/Images/Doll/pc1.jpg',0,0,N'nhựa','1 Ngày',N'300g',2)
Insert into Product values(N'Búp bê khớp mắt thủy tinh đầm xanh và tủ quần áo',215.000,'/Images/Doll/pc2.jpg',0,0,N'nhựa','1 Ngày',N'2kg',2)
Insert into Product values(N'Búp bê mắt thủy tinh váy xòe',199.000,'/Images/Doll/pc3.jpg',0,0,N'nhựa','1 Ngày',N'2kg',2)
Insert into Product values(N'Búp bê trái kiwi và em bé',165.000,'/Images/Doll/pc4.jpg',0,0,N'nhựa','1 Ngày',N'2kg',2)
Insert into Product values(N'Lắp ráp quầy nước giải khát',249.000,'/Images/puzzles/jp.jpg',0,0,N'nhựa, gỗ',N'1 Ngày',N'2kg',3)
Insert into Product values(N'Lắp ráp thế giới khủng long',365.000,'/Images/puzzles/jp2.jpg',0,0,N'nhựa, gỗ',N'1 Ngày',N'2kg',3)
Insert into Product values(N'Lắp ráp quầy khoai tây chiên',249.000,'/Images/puzzles/jp3.jpg',0,0,N'nhựa, gỗ',N'1 Ngày',N'2kg',3)
Insert into Product values(N'Lắp ráp bánh răng funny',105.000,'/Images/puzzles/jp4.jpg',0,0,N'nhựa, gỗ',N'1 Ngày',N'2kg',3)
Insert into Product values(N'Robot biến hình Mini R',318.000,'/Images/Robot/rb5.jpg',0,0,N'sắt nhẹ',N'1 Ngày',N'5kg',5)
Insert into Product values(N'Khủng long bạo chúa chiến đấu T-Rex Đỏ',405.000,'/Images/Robot/rb6.jpg',174.000,0,N'sắt nhẹ',N'1 Ngày',N'5kg',5)
Insert into Product values(N'Robot tự động bắn đĩa (đen)',262.000,'/Images/Robot/rb7.jpg',87.000,0,N'sắt nhẹ',N'1 Ngày',N'5kg',5)
Insert into Product values(N'Rắn đốm tinh tường Cam',459.000,'/Images/Robot/rb8.jpg',0,0,N'sắt nhẹ',N'1 Ngày',N'5kg',5)
Insert into Product values(N'Bandai MGEX Unicorn Gundam ver Ka',4900.000,'/Images/Model_Kid/mk5.jpg',100.000,0,N'sắt-nhẹ-cứng',N'1 Tuần',N'10kg',1)
Insert into Product values(N'PG Unleashed RX-78-2 Gundam Bandai',7800.000,'/Images/Model_Kid/mk6.jpg',0,0,N'sắt-nhẹ-cứng',N'1 Tuần',N'10kg',1)
Insert into Product values(N'Gundam HG WFM Aerial (The Witch from Mercury)',550.000,'/Images/Model_Kid/mk7.jpg',50.000,0,N'sắt-nhẹ-cứng',N'1 Tuần',N'10kg',1)
Insert into Product values(N'HGGBB HG Gundam Helios hàng chính hãng Bandai',520.000,'/Images/Model_Kid/mk8.jpg',0,0,N'sắt-nhẹ-cứng',N'1 Tuần',N'10kg',1)
Insert into Product values(N'Xe điều khiển từ xa màu đỏ',155.000,'/Images/Toy_Car/tc5.jpg',0,0,N'nhựa',N'3 Ngày',N'5kg',6)
Insert into Product values(N'Xe điều khiển từ xa màu vàng',155.000,'/Images/Toy_Car/tc6.jpg',0,0,N'nhựa',N'3 Ngày',N'5kg',6)
Insert into Product values(N'Xe điều khiển từ xa màu xanh',155.000,'/Images/Toy_Car/tc7.jpg',0,0,N'nhựa',N'3 Ngày',N'5kg',6)
Insert into Product values(N'Xe điều khiển địa hình',239.000,'/Images/Toy_Car/tc8.jpg',0,0,N'nhựa',N'3 Ngày',N'5kg',6)
go

--insert table admin
Insert into Adminstrator values(1,N'Tài',N'admin',N'123456')
go
Insert into Adminstrator values(2,N'Tiến',N'admin2',N'654321')
go


Insert into Blog values(1,N'BA MẸ NÊN LÀM GÌ ĐỂ BÉ YÊU CÓ MỘT MÙA GIÁNG SINH ĐÁNG NHỚ?',
N'Làm thiệp Giáng sinh
Giáng sinh năm nay, ba mẹ hãy cùng bé tự tay làm những tấm thiệp handmade thật đẹp và ghi những lời chúc để gửi tặng bạn bè,
 người thân. Đó có thể là một chiếc thiệp hình trang trí cây thông với ý nghĩa trường tồn vĩnh cửu, cầu chúc cuộc sống phồn vinh, 
 hạnh phúc. Hay tấm thiệp trang trí ông già Noel thể hiện tình yêu cao đẹp.
Chắc chắn những người thân yêu sẽ rất vui khi nhận được món quà nhỏ xinh, ý nghĩa này. Hơn nữa, khi làm thiệp Giáng sinh bé sẽ
 có cơ hội thể hiện sự khéo léo và phát huy tư duy sáng tạo của mình.',
N'/Images/Blog/bl1.jpeg',N'/Images/BlogDes/bld1.jpg',15/12/2022,1)
Insert into Blog values(2,N'GỢI Ý NHỮNG MÓN QUÀ GIÁNG SINH XINH LUNG LINH CHO BÉ GÁI',
N'Nếu bé trai thường đam mê những món đồ chơi mạnh mẽ, cá tính, thì bé gái lại có xu hướng yêu thích những
 món đồ xinh xắn, đáng yêu. Vì vậy khi mua quà Giáng sinh cho bé gái, ba mẹ có thể chọn vô số những món quà búp bê
  gấu bông, túi xách, đồ trang điểm... Ngoài ra, ba mẹ cũng có thể tham khảo những món đồ chơi LEGO lắp ráp, đồ chơ
  i đóng vai hay đồ thủ công sáng tạo... để bé có thể phát triển trí tuệ, khả năng của bản thân.
Dưới đây là danh sách gợi ý những món quà Giáng sinh cho bé gái vừa ý nghĩa vừa đẹp mắt. Đảm bảo các công 
chúa nhỏ sẽ bất ngờ và thích mê khi nhận được.
Đồ chơi LEGO Friends Nhà thuyền trên sông',
N'/Images/Blog/bl2.jpg',N'/Images/BlogDes/bld2.jpeg',16/12/2022,2)
Insert into Blog values(3,N'Black Friday - Sự kiện Mua sắm Black Friday 2022',
N'1. MIỄN PHÍ VẬN CHUYỂN
Miễn phí vận chuyển tiêu chuẩn toàn quốc cho đơn hàng từ 400.000 đồng.
Store không giới hạn khối lượng hàng hóa, không giới hạn số lượng đơn hàng. Miễn phí vận chuyển
 hoàn toàn trong các ngày diễn ra sự kiện.
Bạn sẽ thấy tùy chọn "Miễn phí vận chuyển BLACK FRIDAY" ở bước thanh toán. Thời gian giao hàng từ 5 ~ 7 ngày hoặc sớm hơn tùy khu vực.
2. QUÀ TẶNG CHO TẤT CẢ ĐƠN HÀNG
Tất cả đơn hàng trong thời gian diễn ra sự kiện đều có 01 món quà đặc biệt từ M2 DUEL Channel và Store.
Bạn sẽ nhận thêm 01 món quà nữa từ BLACK FRIDAY 2022 tương ứng với giá trị đơn hàng
- Đơn hàng từ 400.000 đồng: quà tặng 01 Booster Pack Yugioh chính hãng 5 lá bài
- Đơn hàng từ 800.000 đồng: quà tặng 01 Booster Pack Yugioh chính hãng 7 lá bài
- Đơn hàng từ 1.200.000 đồng: quà tặng 01 Booster Pack Yugioh chính hãng 9 lá bài
* Quà tặng được tự động trong đơn hàng và bạn không cần thao tác gì thêm.
* Giá trị đơn hàng KHÔNG BAO GỒM phí vận chuyển',
N'/Images/Blog/bl3.jpg',N'/Images/BlogDes/bld3.png',15/9/2022,1)
Insert into Blog values(4,N'Lạ mắt với Rô bốt biến hình xe theo phim hoạt hình',
N'Tobot Z là người anh hùng thứ ba trong loạt phim hoạt hình nổi tiếng Tobot. Người tạo ra chú tobot này là Limo – 
cha của Dylan, ông đã tạo ra một chú rô bốt từ một chiếc xe hơi đẹp mắt. Tobot Z có hệ thống vũ khí trên tay và các khớp linh hoạt như
 của một võ sĩ quyền anh, mang đến cho bé một nhân vật rô bốt hùng mạnh. Chìa khóa của chú rô bốt được đặt trong chiếc đồng hồ, thuận tiện để bé mang theo bên mình khi vui chơi.
Sản phẩm được thiết kế hoàn thiện từng chi tiết thật sắc nét với các chi tiết rõ ràng từ phần đầu, đèn, huy hiệu trên ngực, mặt nạ vàng và
 những hoa văn trang trí trên phần eo. Khi vui chơi, các bé có thể thay đổi hình dáng Tobot Z bằng nhiều cách khác nhau. Ngoài ra, sản phẩm còn kèm theo 4 thẻ đồ chơi và 2 
 nhãn dán hình tobot để bé chơi cùng tobot Z.',
N'/Images/Blog/bl4.jpg',N'/Images/BlogDes/bld4.jpg',10/7/2022,2)
Insert into Blog values(5,N'ĐỒ CHƠI TRẺ EM GIẢM ĐẾN 48%',
N'Cửa hàng Đồ chơi trẻ em chuyên cung cấp đồ chơi an toàn cho trẻ em ở mọi lứa tuổi. Tất cả các sản phẩm tại cửa hàng đều là hàng chính hãng, được làm từ chất liệu cao cấp, 
có nguồn gốc, xuất xứ rõ ràng, cực kỳ an toàn và phù hợp với các bé. Hiện nay, cửa hàng Đồ chơi trẻ em đang áp dụng chương trình khuyến mãi, giảm giá cực sốc lên đến 48%. 
Các mẹ hãy nhanh tay sắm ngay những món đồ chơi thú vị này cho bé yêu nhà mình nhé.
Búp bê Barbie thời trang dạo phố BCH56',
N'/Images/Blog/bl5.png',N'/Images/BlogDes/bld5.png',10/3/2022,1)
Insert into Blog values(6,N'GIÁNG SINH LÀ NGÀY MẤY? PHÂN BIỆT NGÀY 24 VÀ 25 TRONG DỊP LỄ GIÁNG SINH',
N'Lễ hội Giáng sinh hay lễ Thiên Chúa Giáng Sinh, Noel, Christmas, X-mas là ngày lễ lớn của người Công giáo. Ngày lễ này được tổ chức thường niên để kỉ niệm ngày Chúa 
Jesus sinh ra. Không chỉ vậy, Giáng sinh còn là dịp để các thành viên trong gia đình quây quần, đoàn tụ, để mọi người thể hiện tình yêu thương, sự quan tâm, sẻ chia với 
những người xung quanh.
Trong bài viết kỳ trước, ắt hẳn bạn đã biết được nguồn gốc, ý nghĩa của lễ hội Giáng sinh. Hôm nay hãy cùng tìm hiểu năm nay Giáng sinh là ngày mấy? Đồng thời biết cách 
phân biệt ngày 24/12 và ngày 25/12 trong dịp lễ đặc biệt này.
Năm 2022, Giáng sinh là ngày mấy?
Như mọi năm, lễ Giáng sinh sẽ diễn ra từ đêm 24/12 đến hết ngày 25/12 (Dương lịch). Bởi theo quan niệm của người Do Thái, một ngày mới sẽ bắt đầu từ lúc hoàng hôn chứ không 
phải là bình minh. Vì vậy, họ thường tổ chức lễ Giáng sinh vào đêm 24/12 (Lễ vọng) trước khi bắt đầu làm lễ chính thức trong cả ngày 25/12 (Lễ chính ngày).
Trong năm 2022, đêm Giáng sinh sẽ rơi thứ 7 (ngày 24/12 Dương lịch) và ngày Giáng sinh chính thức là chủ nhật (ngày 25/12 Dương lịch).',
N'/Images/Blog/bl6.jpeg',N'/Images/BlodDes/bld6.jpeg',20/12/2022,2)
go

