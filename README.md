# Library  :books:
 
Used Tehnologies:
>* C#/.NET
>* MySQL
>* MVC design pattern

Library management system built in ASP.NET Core 3.1  with books from my own shelves and movies from the best times. <br/>
The database is the following:
![db](https://user-images.githubusercontent.com/61286310/81499725-50887c00-92d6-11ea-9b5e-65b6250d0e8b.png)

This project was meant to be the menagement of a Library which contains items as books and movies. Each item can be borrowed by a member of the library based on his library subscription. For example, if an item has been borrowed, it can be put on hold by another member of the library based on his library subscription. After the first memebr, who borrowed the item, returns it, it goes to the first holding and so on. The item can be marked Lost or Found, as well. Once an item as been lost the current borrow and holds are deleted.
