  --pubs
  use pubs
--1) Select all the author details
	select * from authors
--2) Print the author full name
	select concat(au_fname,' ',au_lname) 'Full author`s name' from authors
--3) Print the titles which are priced less than 10
	select * from titles where price<10
--4) print the number of publisher in each city
	select city, count(pub_id) 'The number of publishers' from publishers
	group by city
--5) print the number of titles published by each publisher
	select pub_name,count(t.title) 'the number of titles' 
	from titles t join publishers p 
	on t.pub_id =p.pub_id
	group by pub_name
--6) Print the total quantity sold of every title
	select t.title_id,qty from titles t join sales s 
	on t.title_id=s.title_id
--7) improve the query in 6 to print the title name and numbers sold ???
	select title,qty from titles t join sales s 
	on t.title_id=s.title_id
--8) print the publisher name and the title name
	select pub_name,title from titles t join publishers p 
	on t.pub_id=p.pub_id
--9) print the publisher name and the total quantity sold(for all the books published under teh publisher)
	select pub_name 'publisher name', sum(qty)
	from (titles t join publishers p
	on t.pub_id=p.pub_id)
	join sales s on t.title_id=s.title_id
	group by pub_name
--10) Print the author full name and the titles he has authored
	select concat(au.au_fname,' ',au.au_lname) 'author name',title
	from authors au join titleauthor tau
	on au.au_id = tau.au_id
	join titles t on tau.title_id=t.title_id
	order by 'author name'
--11) Print the bill number, quanity, price of title and the store address
	select ord_num,qty,price,stor_address
	from (sales s join titles t 
	on s.title_id=t.title_id)
	join stores st on s.stor_id=st.stor_id
--12) Print the employee name and the pulisher name
	select concat(fname,' ',lname) 'employee name',pub_name 'publisher name'
	from employee emp join publishers p
	on emp.pub_id=p.pub_id
--13) Print the publisher name, employee name and their job description
	select concat(fname,' ',lname) 'employee name',pub_name 'publisher name',job_desc 'job description'
	from (employee emp join publishers p
	on emp.pub_id=p.pub_id)
	join jobs j on emp.job_id=j.job_id
--14) print the publisher name and his first employee recruitment date
	select pub_name 'publisher name',min(hire_date)
	from employee emp join publishers p
	on emp.pub_id=p.pub_id
	group by pub_name
--15) print the author name and the average price of his books
	select au.au_id,concat(au.au_fname,' ',au.au_lname) 'author name', avg(price) 'the average price of books'
	from authors au join titleauthor tau
	on au.au_id = tau.au_id
	join titles t on tau.title_id=t.title_id
	group by au.au_id,au.au_fname,au.au_lname
