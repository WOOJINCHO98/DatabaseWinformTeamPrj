drop table reservation
/
create table reservation(reservcode number primary key, usercode number, scrcode number, reservnum number, cardnum VARCHAR2(50), cardpasswd VARCHAR2(50), confirmMsg VARCHAR2(50), bankName VARCHAR2(50), AccountNum VARCHAR2(50), carrier VARCHAR2(50), phoneNum VARCHAR2(50), constraint reservation_fk1 foreign key(usercode) references user_t(usercode),constraint reservation_fk2 foreign key(scrcode) references screening(scrcode))
/
commit
/