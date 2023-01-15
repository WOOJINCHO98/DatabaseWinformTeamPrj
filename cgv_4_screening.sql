drop table screening
/
create table screening(scrcode number primary key, moviecode number, roomcode number, scrdate VARCHAR2(20), scrtime VARCHAR2(20), scrnum number DEFAULT 0,
				constraint screening_fk1 foreign key(moviecode) references movie(moviecode),
				constraint screening_fk2 foreign key(roomcode) references room(roomcode))
/
INSERT INTO screening VALUES (1, 1, 1,  '2022-12-17',  '2022-12-17 10:35:00', 0)
/
INSERT INTO screening VALUES (2, 1, 2,  '2022-12-17',  '2022-12-17 12:10:00' , 0)
/
INSERT INTO screening VALUES (3, 1, 3,  '2022-12-17',  '2022-12-17 14:45:00', 0)
/
INSERT INTO screening VALUES (4, 1, 1,  '2022-12-17',  '2022-12-17 19:10:00', 0)
/
INSERT INTO screening VALUES (5, 1, 1,  '2022-12-17',  '2022-12-17 23:00:00', 0)
/

INSERT INTO screening VALUES (6, 2, 3,  '2022-12-17',  '2022-12-17 09:25:00', 0)
/
INSERT INTO screening VALUES (7, 2, 3,  '2022-12-17',  '2022-12-17 12:00:00' , 0)
/
INSERT INTO screening VALUES (8, 2, 2,  '2022-12-17',  '2022-12-17 14:20:00', 0)
/
INSERT INTO screening VALUES (9, 2, 2,  '2022-12-17',  '2022-12-17 17:00:00', 0)
/
INSERT INTO screening VALUES (10, 2, 1,  '2022-12-17',  '2022-12-17 20:00:00', 0)
/

INSERT INTO screening VALUES (11, 3, 1,  '2022-12-17',  '2022-12-17 09:50:00', 0)
/
INSERT INTO screening VALUES (12, 3, 2,  '2022-12-17',  '2022-12-17 12:30:00' , 0)
/
INSERT INTO screening VALUES (13, 3, 2,  '2022-12-17',  '2022-12-17 15:00:00', 0)
/
INSERT INTO screening VALUES (14, 3, 2,  '2022-12-17',  '2022-12-17 17:50:00', 0)
/
INSERT INTO screening VALUES (15, 3, 1,  '2022-12-17',  '2022-12-17 20:35:00', 0)
/

INSERT INTO screening VALUES (16, 4, 3,  '2022-12-17',  '2022-12-17 13:25:00', 0)
/
INSERT INTO screening VALUES (17, 4, 3,  '2022-12-17',  '2022-12-17 14:50:00' , 0)
/
INSERT INTO screening VALUES (18, 4, 2,  '2022-12-17',  '2022-12-17 17:16:00', 0)
/
INSERT INTO screening VALUES (19, 4, 1,  '2022-12-17',  '2022-12-17 19:50:00', 0)
/
INSERT INTO screening VALUES (20, 4, 1,  '2022-12-17',  '2022-12-17 22:00:00', 0)
/

INSERT INTO screening VALUES (21, 1, 1,  '2022-12-18',  '2022-12-18 08:25:00', 0)
/
INSERT INTO screening VALUES (22, 1, 2,  '2022-12-18',  '2022-12-18 10:30:00', 0)
/
INSERT INTO screening VALUES (23, 1, 2,  '2022-12-18',  '2022-12-18 13:10:00', 0)
/
INSERT INTO screening VALUES (24, 1, 2,  '2022-12-18',  '2022-12-18 16:20:00', 0)
/
INSERT INTO screening VALUES (25, 1, 1,  '2022-12-18',  '2022-12-18 19:15:00', 0)
/

INSERT INTO screening VALUES (26, 2, 1,  '2022-12-18',  '2022-12-18 13:30:00', 0)
/
INSERT INTO screening VALUES (27, 2, 3,  '2022-12-18',  '2022-12-18 16:10:00', 0)
/
INSERT INTO screening VALUES (28, 2, 2,  '2022-12-18',  '2022-12-18 18:40:00', 0)
/
INSERT INTO screening VALUES (29, 2, 2,  '2022-12-18',  '2022-12-18 21:30:00', 0)
/
INSERT INTO screening VALUES (30, 2, 2,  '2022-12-18',  '2022-12-18 23:50:00', 0)
/

INSERT INTO screening VALUES (31, 3, 1,  '2022-12-18',  '2022-12-18 11:15:00', 0)
/
INSERT INTO screening VALUES (32, 3, 1,  '2022-12-18',  '2022-12-18 13:50:00', 0)
/
INSERT INTO screening VALUES (33, 3, 3,  '2022-12-18',  '2022-12-18 16:10:00', 0)
/
INSERT INTO screening VALUES (34, 3, 3,  '2022-12-18',  '2022-12-18 18:50:00', 0)
/
INSERT INTO screening VALUES (35, 3, 2,  '2022-12-18',  '2022-12-18 21:40:00', 0)
/

INSERT INTO screening VALUES (36, 4, 1,  '2022-12-18',  '2022-12-18 12:00:00', 0)
/
INSERT INTO screening VALUES (37, 4, 1,  '2022-12-18',  '2022-12-18 14:50:00', 0)
/
INSERT INTO screening VALUES (38, 4, 3,  '2022-12-18',  '2022-12-18 17:35:00', 0)
/
INSERT INTO screening VALUES (39, 4, 4,  '2022-12-18',  '2022-12-18 20:10:00', 0)
/
INSERT INTO screening VALUES (40, 4, 4,  '2022-12-18',  '2022-12-18 22:50:00', 0)
/

INSERT INTO screening VALUES (41, 1, 2,  '2022-12-19',  '2022-12-19 09:10:00', 0)
/
INSERT INTO screening VALUES (42, 1, 3,  '2022-12-19',  '2022-12-19 11:50:00', 0)
/
INSERT INTO screening VALUES (43, 1, 1,  '2022-12-19',  '2022-12-19 14:15:00', 0)
/
INSERT INTO screening VALUES (44, 1, 1,  '2022-12-19',  '2022-12-19 16:50:00', 0)
/
INSERT INTO screening VALUES (45, 1, 2,  '2022-12-19',  '2022-12-19 19:30:00', 0)
/

INSERT INTO screening VALUES (46, 2, 1,  '2022-12-19',  '2022-12-19 08:50:00', 0)
/
INSERT INTO screening VALUES (47, 2, 3,  '2022-12-19',  '2022-12-19 11:30:00', 0)
/
INSERT INTO screening VALUES (48, 2, 2,  '2022-12-19',  '2022-12-19 14:00:00', 0)
/
INSERT INTO screening VALUES (49, 2, 2,  '2022-12-19',  '2022-12-19 16:55:00', 0)
/
INSERT INTO screening VALUES (50, 2, 3,  '2022-12-19',  '2022-12-19 20:20:00', 0)
/

INSERT INTO screening VALUES (51, 3, 2,  '2022-12-19',  '2022-12-19 12:25:00', 0)
/
INSERT INTO screening VALUES (52, 3, 1,  '2022-12-19',  '2022-12-19 15:10:00', 0)
/
INSERT INTO screening VALUES (53, 3, 3,  '2022-12-19',  '2022-12-19 17:50:00', 0)
/
INSERT INTO screening VALUES (54, 3, 2,  '2022-12-19',  '2022-12-19 20:40:00', 0)
/
INSERT INTO screening VALUES (55, 3, 3,  '2022-12-19',  '2022-12-19 23:20:00', 0)
/

INSERT INTO screening VALUES (56, 4, 4,  '2022-12-19',  '2022-12-19 11:10:00', 0)
/
INSERT INTO screening VALUES (57, 4, 3,  '2022-12-19',  '2022-12-19 14:00:00', 0)
/
INSERT INTO screening VALUES (58, 4, 3,  '2022-12-19',  '2022-12-19 17:00:00', 0)
/
INSERT INTO screening VALUES (59, 4, 3,  '2022-12-19',  '2022-12-19 19:20:00', 0)
/
INSERT INTO screening VALUES (60, 4, 1,  '2022-12-19',  '2022-12-19 21:55:00', 0)
/




commit
/