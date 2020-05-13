# Library  :books:
 
Used Tehnologies:
>* C#/.NET
>* MySQL
>* MVC design pattern

Library management system built in ASP.NET Core 3.1  with books from my own shelves and movies from the best times. <br/>
The database is the following:
![db](https://user-images.githubusercontent.com/61286310/81499725-50887c00-92d6-11ea-9b5e-65b6250d0e8b.png)

This project was meant to be the menagement of a Library which contains the members of the library and the items, as books and movies.<br/>
Each item can be **borrowed**, if its status is "Available", by a member of the library based on his library subscription and he has a due date of 30 days to return it. On the other hand, if an item has been borrowed (so the status of the item will be "Borrowed"), it can be put on **hold** by another member of the library based on his library subscription, the status changing to "On Hold". After the first member, who borrowed the item, returns it, it goes to the first holding and so on if there are multiple holds on the same item.<br/>
The item can be marked **Lost** or **Found**, as well. Once an item as been lost, the current borrow and holds are deleted and the status of the item will change to "Lost". If it is Found, it is not borrowed by anyone and either on hold for someone and its status goes back to "Available". <br/>
The Library can check the members profiles by clicking on the "Members" page. There, the names, the subscription Id and fees are shown. If clicked on the profile it can be seen a picture of the member and more details about him, as address, phone number, gender etc.
