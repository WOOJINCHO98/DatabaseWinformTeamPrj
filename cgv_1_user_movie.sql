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
insert into user_t values(1, 'Honggildong123', '1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', 'ȫ�浿', '����� ������', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(2, 'Parkgildong123','1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', '�ڱ浿', '���ν� ���ﱸ', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(3, 'Leegildong123','1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', '�̱浿', '����� �����', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(4, 'Kimgildong123','1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', '��浿', '����� �߶���', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(5, 'test', '1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20', 'test', '����� ������', '010-1234-1234', 'VIP', 10, 0)
/
insert into user_t values(6, 'test', '1234', '111@bc.ac.kr', '1998-07-28', '2022-11-20' ,'test', '����� ������', '010-1234-1234','VIP' ,10, 0)
/
insert into user_t values(8, 'admin', 'admin', '111@bc.ac.kr', '1998-07-28', '2022-11-20' ,'test', '����� ������', '010-1234-1234','VIP' ,10, 1)
/
insert into movie values(1,'���漭','���̾� ��۷�', '��ƼƼ�� ����Ʈ', '�׼�', '2022.11.09', '2022.12.25', 12, 161, 8000, '��ĭ�ٸ� ���Ѷ�! �Ŵ��� �� ������ �浹, ����� �� ������ ������ ���۵ȴ�!!')
/
insert into movie values(2,'���ú� ','Ȳ��ȣ', '�跡��', '�׼�', '2022.11.16', '2022.12.23', 12, 110, 6000000, '������ Ŀ���� ���� ��.��.��.��')
/
insert into movie values(3,'����','������', '������', '�θེ, ���', '2022.11.16', '2022.12.30', 12, 114, 5000000, '1999��, ���� ù���� ���ϰ� �� �Ѽ��� ������ ���� ģ������ HAM �����⸦ ������..')
/
insert into movie values(4,'�û���', '������', '���ؿ�', '������', '2022.11.23', '2022.12.19', 15, 118, 4000000, '���������� �پ ħ�� �Ƿ��� ���� ����� ���� �������͡����� �� ���ָ� �����޾�.')
/
insert into grade_detail values(1, 4, 1, 1, '�� ���漭 �ʹ� ��վ��.')
/
insert into grade_detail values(2, 1, 1, 4, '������� ��ȭ�׿�.')
/
insert into grade_detail values(3, 5, 1, 1, '�ȳ� �츰 �� �� �־�.')
/
commit
/