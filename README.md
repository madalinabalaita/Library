# Library  :books:
 
Used Tehnologies:
>* C#/.NET
>* MySQL
>* MVC design pattern

Library management system built in ASP.NET Core 3.1  with books from my own shelves and movies from the best times. <br/>
The database is the following:
![db](https://user-images.githubusercontent.com/61286310/81499725-50887c00-92d6-11ea-9b5e-65b6250d0e8b.png)

This project was meant to be the menagement of a Library which contains the members of the library and the items, as books and movies.<br\>
Each item can be borrowed by a member of the library based on his library subscription and he has a due date of 30 days to return it. On the other hand, if an item has been borrowed, it can be put on hold by another member of the library based on his library subscription. After the first memeber, who borrowed the item, returns it, it goes to the first holding and so on if there are multiple holds on the same item. The item can be marked Lost or Found, as well.
Once an item as been lost the current borrow and holds are deleted. If it is Found, it is not borrowed by anyone and either on hold for someone.
