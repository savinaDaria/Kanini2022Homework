use pubs

--1) Select all the author's details
select* from authors

--2) print all the author's full name
select concat(au_fname ,' ',au_lname )'Full name' from authors

--3) Print the average price , total price of all the titles
select round(avg(price),2) 'Average price', round(sum(price),2) 'Total price' from titles

--4) Print the average price of a titles published by '0736'
select avg(price) from titles where pub_id='0736'

--5) print the titles whicha have advance min of 3200 and maximum of 5000
select title from titles where advance between 3200 and 5000

--6) Print the titles which are of type 'psychology' or 'mod_cook'
select title from titles where type in ('psychology','mod_cook')

--7) print all titles published before '1991-06-09 00:00:00.000'???
select title,pubdate from titles where pubdate < '1991-06-09 00:00:00.000'

--8) Select all the authors from 'CA'
select* from authors where state='CA'

--9) Print the average price of titles in every type
select type,avg(price) 'The average price of titles' from titles
group by type

--10) print the sum of price of all the books pulished by every publisher
select pub_id,sum(price) "Total price" from titles
group by pub_id

--11) Print the first published title in every type
select type,min(title), min(pubdate) 'pubdate' from titles 
group by type
order by type

--12) calculate the total royalty for every publisher
select t.pub_id,pub_name, sum(royalty) 'total royalty' 
from titles t join publishers p on t.pub_id=p.pub_id
group by t.pub_id,pub_name

--13) print the titles sorted by published date
select title, pubdate from titles
order by pubdate

--14) print the titles sorted by publisher then by price
select title, pub_id,price from titles
order by pub_id,price

--15) Print the books published by authors from 'CA'
select distinct title from titles t join titleauthor tau on t.title_id=tau.title_id
join authors au on tau.au_id=au.au_id
where au.state='CA'

--16) Print the author name of books whcih have royalty more than the average royalty of all the titletes
select * from titles
select * from authors

--17) Print all the city and the number of pulishers in it, only if the city has more than one publisher
select city, count(pub_id) 'the number of publishers' from publishers
group by city
having count(pub_id)>1

--18) Print the total number of orders for every title
select title_id,sum(qty)'total number of titles' from sales
group by title_id

--19) Prin the total number of titles in evry order
select qty 'total number of titles' from sales