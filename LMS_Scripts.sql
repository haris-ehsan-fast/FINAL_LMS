use master
go
drop database lms
go
create database lms
go
use lms
go

create table publisher
(
	publ_id varchar(12) primary key,
	[name] varchar(50) not null unique
)
create table author
(
	author_id varchar(12) primary key,
	[name] varchar(50) not null unique
)
create table [admin]
(
	admin_id varchar(12) primary key,
	[name] varchar(50) not null,
	pass varchar(12) not null,
	ph_no char(11) not null, 
	gender varchar(10) not null,
	[address] varchar(50) not null,
	dob date not null,
	email varchar(50) not null,
)
create table book
(
	book_id varchar(12) primary key,
	title varchar(50) not null, 
	lingo varchar(50) not null,
	genre varchar(50) not null,
	num_act int not null,
	num_curr int not null,
	publ_yr int not null,
	publ_id varchar(12) foreign key references publisher(publ_id),
	auth_id varchar(12) foreign key references author(author_id),
	[des] nvarchar(MAX),
	img_link nvarchar(MAX)
)

create table packages
(
	pkg_id int primary key,
	duration int not null, --considered in days
	[bk_count] int not null,
	amount int not null
)

create table member
(
	mem_id varchar(12) primary key,
	[name] varchar(50) not null,
	pass varchar(12) not null,
	ph_no char(11) not null, 
	gender varchar(10) not null,
	[address] varchar(50) not null,
	dob date not null,
	email varchar(50) not null,
	mem_pkg_id int foreign key references packages(pkg_id)
)

create table borrowing
(
	mem_id varchar(12) foreign key references member(mem_id) not null,
	book_id varchar(12) foreign key references book(book_id) not null,
	iss_date date not null,
	exp_ret_date date not null,
	act_ret_date date null,
	review varchar(MAX) null,
	primary key (mem_id, book_id)
)
alter table[dbo].borrowing with check add constraint fk1 foreign key (mem_id) references member (mem_id) on delete cascade
alter table[dbo].borrowing with check add constraint fk2 foreign key (book_id) references book (book_id) on delete cascade


--packages
insert [dbo].packages ([pkg_id],[bk_count],[duration],[amount]) 
values(0,2,14,50)

insert [dbo].packages ([pkg_id],[bk_count],[duration],[amount]) 
values(1,4,28,100)

insert [dbo].packages ([pkg_id],[bk_count],[duration],[amount]) 
values(2,5,35,150)


--[admin]
insert [dbo].[admin]([admin_id],[name],[pass],[ph_no],[gender],[address],[dob],[email])
values('1089','Maha','maha123','03213567910','Female','1-A/johar town,lhr','2000-09-23','maha@gmail.com')
insert [dbo].[admin]([admin_id],[name],[pass],[ph_no],[gender],[address],[dob],[email])
values('1184','Hassan','hassan123','03213567910','Male','2-B/johar town,lhr','2001-09-02','hassan@gmail.com')
insert [dbo].[admin]([admin_id],[name],[pass],[ph_no],[gender],[address],[dob],[email])
values('2308','Ayesha','ayesha123','03213567910','Female','3-C/johar town,lhr','2000-11-05','ayesha@gmail.com')


select* from [admin]
select* from member
select* from publisher
select* from author
select* from book

--proc to login for member
create procedure loginMember
@mem_id varchar(12),
@pass varchar(12),
@found int output
AS
BEGIN
	set @found=0
	IF EXISTS(SELECT * FROM member WHERE mem_id=@mem_id AND pass=@pass)
	begin	
		set @found=1
	end
END


--proc to login for admin
create procedure loginAdmin
@aid varchar(12),
@pass varchar(12),
@found int output
AS
BEGIN
	set @found=0
	IF EXISTS(SELECT * FROM admin WHERE admin_id=@aid AND pass=@pass)
	begin	
		set @found=1
	end
END


--proc to sign up for member
create procedure signup
@mem_id varchar(12),
@name varchar(50),
@pass varchar(12),	
@ph_no char(11), 
@gender varchar(10),	
@address varchar(50),
@dob varchar(50),
@email varchar(50),
@found int output
AS
BEGIN 
begin transaction
save transaction savepoint
	set @found=0
	begin try
	IF EXISTS(SELECT * FROM member WHERE mem_id=@mem_id)
	begin 
		set @found=1 --member exists already
	end
	else
	begin
		set @found=2
		insert into member(mem_id,[name],pass,ph_no,gender,[address],dob,email,mem_pkg_id)
		values (@mem_id,@name,@pass,@ph_no,@gender,@address,@dob,@email, 0)
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to add publisher
create procedure addPublisher
@pid varchar(12),
@pname varchar(50),
@pfound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @pfound=0
	begin try
	IF EXISTS(SELECT * FROM publisher WHERE publ_id=@pid)
	begin 
		set @pfound=1 --publisher id already exists
	end
	else
	begin
		IF EXISTS(SELECT * FROM publisher WHERE name=@pname)
		begin
			set @pfound=2 --publisher name already exists
		end
		else
		begin
			insert into publisher(publ_id,[name])
			values(@pid,@pname)
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to delete publisher
create procedure delPublisher
@pid varchar(12),
@pdfound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @pdfound=0
	begin try
	IF EXISTS(SELECT * FROM publisher WHERE publ_id=@pid)
	begin
		set @pdfound=1 --publisher id exists
		IF (SELECT COUNT(*) FROM book JOIN publisher on book.publ_id=publisher.publ_id WHERE publisher.publ_id=@pid) = 0
		begin
			set @pdfound=2 --can be deleted
			delete from publisher where publ_id=@pid
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END

--proc to update publisher
create procedure upPublisher
@pid varchar(12),
@pname varchar(50),
@pufound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @pufound=0
	begin try
	IF EXISTS(SELECT * FROM publisher WHERE publ_id=@pid)
	begin 
		set @pufound=1 --publisher exists
		IF (SELECT COUNT(*) FROM book JOIN publisher on book.publ_id=publisher.publ_id WHERE publisher.publ_id=@pid) = 0
		begin
			set @pufound=2 --can be updated
			update publisher 
			set 
			[name]=@pname 
			where publ_id=@pid
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to add author
create procedure addAuthor
@aid varchar(12),
@aname varchar(50),
@afound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @afound=0
	begin try
	IF EXISTS(SELECT * FROM author WHERE author_id=@aid)
	begin 
		set @afound=1 --author id already exists
	end
	else
	begin
		IF EXISTS(SELECT * FROM author WHERE name=@aname)
		begin 
			set @afound=2 --author name already exists
		end
		else
		begin
		insert into author(author_id,[name])
		values(@aid,@aname)
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to delete author
create procedure delAuthor
@aid varchar(12),
@adfound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @adfound=0
	begin try
	IF EXISTS(SELECT * FROM author WHERE author_id=@aid)
	begin 
		set @adfound=1 --author id exists
		IF (SELECT COUNT(*) FROM book JOIN author on book.auth_id=author.author_id WHERE author_id=@aid) = 0
		begin
			set @adfound=2 --can be deleted
			delete from author where author_id=@aid
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to update author
create procedure upAuthor
@aid varchar(12),
@aname varchar(50),
@aufound int output
AS
BEGIN
begin transaction 
save transaction savepoint
	set @aufound=0
	begin try
	IF EXISTS(SELECT * FROM author WHERE author_id=@aid)
	begin
		set @aufound=1 --author exists
		IF (SELECT COUNT(*) FROM book JOIN author on book.auth_id=author.author_id WHERE author_id=@aid) = 0
		begin
			set @aufound=2 --can be updated
			update author 
			set 
			[name]=@aname 
			where author_id=@aid
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to delete member
create procedure delMember
@mid varchar(12),
@mfound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @mfound=0 --does not exist
	begin try
	IF EXISTS(SELECT * FROM member WHERE member.mem_id=@mid)
	begin
		set @mfound=1 --member id exists
		IF (SELECT COUNT(*) FROM borrowing WHERE borrowing.mem_id=@mid and borrowing.act_ret_date is null) = 0
		begin
			set @mfound=2 --can be deleted
			delete from member 
			where member.mem_id=@mid
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to update member
create procedure upMember
@mid varchar(12),
@name varchar(50),
@pass varchar(12),	
@ph_no char(11), 
@gender varchar(10),	
@address varchar(50),
@dob varchar(50),
@email varchar(50)
AS
BEGIN 
	Update member
	set 
	member.name=@name, 
	member.pass=@pass, 
	member.dob=@dob, 
	member.address=@address, 
	member.email=@email, 
	member.gender=@gender,
	member.ph_no=@ph_no
	where mem_id=@mid
END


--proc to update admin
create procedure upAdmin
@aid varchar(12),
@name varchar(50),
@pass varchar(12),	
@ph_no char(11), 
@gender varchar(10),	
@address varchar(50),
@dob varchar(50),
@email varchar(50)
AS
BEGIN 
	Update admin
	set 
	admin.name=@name, 
	admin.pass=@pass, 
	admin.dob=@dob, 
	admin.address=@address, 
	admin.email=@email, 
	admin.gender=@gender,
	admin.ph_no=@ph_no
	where admin.admin_id=@aid
END

--proc to update member package
create procedure upMemberPkg
@mid varchar(12),
@pid int,
@umpfound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @umpfound=0
	begin try
	IF EXISTS(SELECT * FROM packages WHERE pkg_id=@pid)
	begin 
		set @umpfound=1 --package exists
		IF EXISTS(SELECT * FROM [member] WHERE mem_id=@mid)
		begin
			set @umpfound=2 --member exists
			update [member] set [mem_pkg_id]=@pid where mem_id=@mid
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to add book
create procedure addBook
@bid varchar(12),
@title varchar(50), 
@lingo varchar(50),
@genre varchar(50),
@num_act int,
@num_curr int,
@publ_yr int,
@publ varchar(50),
@author varchar(50),
@des nvarchar(MAX),
@img_link nvarchar(MAX),
@bafound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @bafound=0
	begin try
	IF EXISTS(SELECT * FROM book WHERE book_id=@bid)
	begin 
		set @bafound=1 --book already exists
	end
	else
	begin
	declare @pid varchar(12)
	set @pid = (select publ_id from publisher where name=@publ)
	declare @aid varchar(12)
	set @aid = (select author_id from author where name=@author)
		insert into book(book_id, title, lingo, genre, num_act, num_curr, publ_yr, publ_id, auth_id, [des], img_link)
		values(@bid,@title,@lingo,@genre,@num_act,@num_curr,@publ_yr,@pid,@aid,@des,@img_link)
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to delete book
create procedure delBook
@bid varchar(12),
@bdfound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @bdfound=0 --does not exist
	begin try
	IF EXISTS(SELECT * FROM book WHERE book_id=@bid)
	begin 
		set @bdfound=1 --book id exists
		IF (SELECT COUNT(*) FROM borrowing WHERE borrowing.book_id=@bid and borrowing.act_ret_date is null) = 0
		begin
			set @bdfound=2 --can be deleted
			delete from book 
			where book.book_id=@bid
		end
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to update book
create procedure upBook
@bid varchar(12),
@title varchar(50), 
@lingo varchar(50),
@genre varchar(50),
@num_act int,
@num_curr int,
@publ_yr int,
@publ varchar(50),
@author varchar(50),
@des nvarchar(MAX),
@img_link nvarchar(MAX),
@bufound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @bufound=0 --does not exist
	begin try
	IF EXISTS(SELECT * FROM book WHERE book.book_id=@bid)
	begin
		set @bufound=1
		declare @pid varchar(12)
		set @pid = (select publ_id from publisher where name=@publ)
		declare @aid varchar(12)
		set @aid = (select author_id from author where name=@author)
		Update book
		set
		book.title=@title,
		book.lingo=@lingo,
		book.genre=@genre,
		book.num_act=@num_act,
		book.num_curr=@num_curr,
		book.publ_yr=@publ_yr,
		book.publ_id=@pid,
		book.auth_id=@aid,
		book.des=@des,
		book.img_link=@img_link
		where book.book_id=@bid
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to issue book
create procedure issueBook
@bid varchar(12),
@mid varchar(12),
@issuedate varchar(50),
@ifound int output
AS
BEGIN
begin transaction savepoint
	set @ifound=0 --cannot issue book
	declare @nobks int
	set @nobks = (select packages.bk_count
				from member join packages on member.mem_pkg_id = packages.pkg_id
				where member.mem_id=@mid)
	begin try
	IF (select count(*) from borrowing where mem_id=@mid and act_ret_date is null) < @nobks
	begin
		set @ifound=1 --can issue book
		declare @expdate varchar(50)
		set @expdate = (select convert(varchar, DATEADD(DAY,packages.duration,@issuedate), 23)
					from member join packages on member.mem_pkg_id = packages.pkg_id
					where member.mem_id=@mid)
		insert into [dbo].borrowing(mem_id, book_id, iss_date, exp_ret_date)
		values(@mid, @bid, @issuedate, @expdate)
		update book
		set num_curr=num_curr-1
		where book.book_id=@bid
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END


--proc to return book
create procedure returnBook
@bid varchar(12),
@mid varchar(12),
@retdate varchar(50),
@rbfound int output
AS
BEGIN
begin transaction
save transaction savepoint
	set @rbfound=0 --already returned
	begin try
	IF (select COUNT(*) from borrowing where mem_id=@mid and book_id=@bid and act_ret_date is null) = 1
	begin
		set @rbfound=1 --is being returned
		update borrowing
		set borrowing.act_ret_date=@retdate
		where borrowing.mem_id=@mid and borrowing.book_id=@bid
		update book
		set num_curr=num_curr+1
		where book.book_id=@bid
	end
	end try
	begin catch 
	if @@trancount>0
	begin 
		rollback transaction savepoint
	end
end catch
commit transaction
END

--proc to load member borrowing details
create procedure memberBookLoad
@mid varchar(12)
AS
BEGIN
	SELECT * 
	from ((borrowing join book on borrowing.book_id = book.book_id) join publisher on book.publ_id=publisher.publ_id) join author on book.auth_id=author.author_id
	where borrowing.mem_id=@mid
END


--proc to add review
create procedure addReview
@mid varchar(12),
@bid varchar(12),
@rev varchar(MAX)
AS
BEGIN
	update borrowing
	set review=@rev
	where mem_id=@mid and book_id=@bid
END
