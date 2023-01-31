CREATE SEQUENCE SPENDING_SEQ
  START WITH 1
  INCREMENT BY 1
  MINVALUE 1
  NOCYCLE
/
create table spending(spendingcode number primary key, moneycode number not null, spendingmoney number not null,
				constraint spending_fk1 foreign key(moneycode) references moneycode(moneycode))
/
commit
/ 