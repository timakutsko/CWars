use cw_joinwithcount;

insert into people (name) values ('Tima');
insert into people (name) values ('Alina');

insert into toys (name, people_id) values ('Zeliboba', 1);
insert into toys (name, people_id) values ('PacaVaca', 1);
insert into toys (name, people_id) values ('MacBook', 2);

select people.id, people.name, count(toys.id) as toy_count from people
	inner join toys on people.id = toys.people_id
    group by people.id;