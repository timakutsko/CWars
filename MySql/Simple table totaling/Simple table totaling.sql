use `cw_simple table totaling`;

select * from people;
insert into people(name, points, clan) values('Tima', 75, 'Man');
insert into people(name, points, clan) values('Alina', 85, 'Woman');

CALL creator(3, 'Bro', 'Man');
CALL creator(3, 'Sist', 'Woman');

insert into people(name, points) values('SomePerson1', 85);
insert into people(name, points) values('SomePerson2', 135);
insert into people(name, points, clan) values('Brooo', 50, 'Man');
insert into people(name, points, clan) values('Sist', 50, 'Woman');

select 
	RANK() OVER (ORDER BY sum(points) DESC) as current_rank,
    IF(clan IS NULL, 'no clan specified', clan) as clan, 
    sum(points) as total_points,
    count(*) as total_people
from people
group by clan;