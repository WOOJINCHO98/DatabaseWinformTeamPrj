drop table grade_detail
/
drop table user_t
/
drop table admin_t
/
drop table movie
/
drop SEQUENCE NO_SEQ
/
CREATE SEQUENCE NO_SEQ
  START WITH 20
  INCREMENT BY 1
  MINVALUE 1
  NOCYCLE
/
create table user_t(userCode number primary key, userId varchar(20), password varchar(20), email varchar(50), birth  date, registerDate  date default sysdate, name varchar(50), address varchar(60), phoneNum varchar(50), userGrade varchar(20) default 'BASIC', viewPerMonth number default 0, userMod number default 0)
/
create table admin_t(adminCode number primary key, adminId varchar(20), password varchar(20), email varchar(20), registerDate  date default sysdate, name varchar(20), phoneNum varchar(20))
/
create table movie(movieCode number primary key, title varchar(20), director varchar(40), mainActor varchar(40), janre varchar(20), releaseDate varchar(20), endDate varchar(20), ageLimit number, runtime number, numOfSpect number, explanation varchar(200))
/
create table grade_detail(gradeCode number, grade number, userCode number, movieCode number, review varchar(100), foreign key(movieCode) references movie(movieCode),  foreign key(userCode) references user_t(userCode))
/
insert into user_t values(1, 'Honggildong123', '1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', '홍길동', '서울시 강남구', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(2, 'Parkgildong123','1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', '박길동', '용인시 기흥구', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(3, 'Leegildong123','1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', '이길동', '서울시 노원구', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(4, 'Kimgildong123','1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', '김길동', '서울시 중랑구', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(5, 'test', '1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', 'test', '서울시 강남구', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(6, 'test', '1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20' ,'test', '서울시 강남구', '010-1234-1234','VIP' ,10, 0)
/
insert into user_t values(8, 'admin', 'admin', '111@bc.ac.kr', '1998-07-28', '2022-11-20' ,'test', '서울시 강남구', '010-1234-1234','VIP' ,10, 1)
/
insert into movie values(1,'블랙펜서','라이언 쿠글러', '레티티아 라이트', '액션', '2022.11.09', '2022.12.25', 12, 161, 8000, '와칸다를 지켜라! 거대한 두 세계의 충돌, 운명을 건 최후의 전투가 시작된다!!')
/
insert into movie values(2,'데시벨 ','황인호', '김래원', '액션', '2022.11.16', '2022.12.23', 12, 110, 6000000, '소음이 커지는 순간 폭.발.한.다')
/
insert into movie values(3,'동감','서은영', '여진구', '로멘스, 멜로', '2022.11.16', '2022.12.30', 12, 114, 5000000, '1999년, 용은 첫눈에 반하게 된 한솔을 사로잡기 위해 친구에게 HAM 무전기를 빌린다..')
/
insert into movie values(4,'올빼미', '안태진', '류준열', '스릴러', '2022.11.23', '2022.12.19', 15, 118, 4000000, '맹인이지만 뛰어난 침술 실력을 지닌 경수는 어의 ‘이형익’에게 그 재주를 인정받아.')
/
insert into grade_detail values(1, 4, 1, 1, '와 블랙펜서 너무 재밌어요.')
/
insert into grade_detail values(2, 1, 1, 4, '감명깊은 영화네요.')
/
insert into grade_detail values(3, 5, 1, 1, '안녕 우린 할 수 있어.')
/
commit
/