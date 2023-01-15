CREATE SEQUENCE INCOME_SEQ
  START WITH 1
  INCREMENT BY 1
  MINVALUE 1
  NOCYCLE
/
create table income(incomecode number primary key, moneycode number not null, reservincome number not null,
				constraint income_fk1 foreign key(moneycode) references moneycode(moneycode))
/
commit
/
