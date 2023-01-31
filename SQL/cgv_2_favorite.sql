drop table favorite
/
create table favorite(userCode number , 
				movieCode number , 
				primary key(userCode,movieCode),
				constraint favorite_fk1 foreign key(userCode) references user_t(userCode),
				constraint favorite_fk2 foreign key(movieCode) references movie(movieCode)
)
/
commit
/