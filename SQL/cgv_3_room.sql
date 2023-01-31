drop table room
/
create table room(roomcode number primary key, roomname varchar(10), ronum number, columnnum number, seatnum number)
/
INSERT INTO room VALUES (1, 'A', 6, 15, 90)
/
INSERT INTO room VALUES (2, 'B', 6, 14, 84)
/
INSERT INTO room VALUES (3, 'C', 5, 15, 75)
/
INSERT INTO room VALUES (4, 'C', 5, 14, 70)
/
commit
/