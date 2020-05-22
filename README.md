# Library  :books:
 
Used Tehnologies:
>* C#/.NET
>* MySQL
>* MVC design pattern

Library management system built in ASP.NET Core 3.1  with books from my own shelves and movies from the best times. <br/>
The database is the following:
![db](https://user-images.githubusercontent.com/61286310/81499725-50887c00-92d6-11ea-9b5e-65b6250d0e8b.png)
<br/>
This project was meant to be the management of a Library which contains the members of the library and the items, as books and movies.
<br/>
In the opening of the project you will find the button to view the collection of items or the list of members.
![1](https://user-images.githubusercontent.com/61286310/82140255-4ebf3b00-9837-11ea-97be-44f5d1e9036b.gif)
<br/>

By clicking on the View Collection two tables will show.
* One for Books, with the book cover, title, athor, genre, number and a view button. 
* Another one for movies with the movie poster, title, director, genre and a view button.
![2](https://user-images.githubusercontent.com/61286310/82140519-bc6b6700-9837-11ea-9e6f-d775b0dc29a3.gif)

<br/>
Once the view button it's clicked, a bigger image of the item will appear, title, author or director, type of the item , genre, a small important phrase from a book/movie, a borrow button, a lost button and a table with ISBN, Dewey Number (only for books), Number of pages/Lenght of the Movie in minutes and the price of replacement if lost.A well as the mark lost/ found button, borrow/return button, hold if borrow, borrowed history, on hold history.

As we click the search bar and search for an item the item will show up , as well as the view button found in the collection section.

![3](https://user-images.githubusercontent.com/61286310/82140646-ecffd080-9838-11ea-9837-1acb8f46ab75.gif)

<br/>

* Each item can be **borrowed**, if its status is "Available", by a member of the library based on his library subscription and he has a due date of 30 days to return it. On the other hand, if an item has been borrowed (so the status of the item will be "Borrowed"), it can be put on **hold** by another member of the library based on his library subscription, the status changing to "On Hold". When the member will hold an item a remark providing the current number of the holds on that item is shown.After the first member, who borrowed the item, returns it, it goes to the first holding and so on if there are multiple holds on the same item.<br/>
 ![7](https://user-images.githubusercontent.com/61286310/82639094-b6e39780-9c10-11ea-8df8-88589adf788c.png)
<br/>
 

* The item can be marked **Lost** or **Found**, as well. Once an item as been lost, the current borrow and holds are deleted and the status of the item will change to "Lost". If it is Found, it is not borrowed by anyone and either on hold for someone and its status goes back to "Available". <br/>


![5](https://user-images.githubusercontent.com/61286310/82140824-34d32780-983a-11ea-821c-9abe6277b758.gif)
<br/>
<br>
* The Library can check the members profiles by clicking on the "View Members". There, the names, the subscription Id and fees are shown. If clicked on the profile it can be seen a picture of the member and more details about him, as date of birth, address, phone number, gender etc. As well as the current holds and lendt items.<br/>
![6](https://user-images.githubusercontent.com/61286310/82639111-be0aa580-9c10-11ea-8b85-c0a0b3f25970.gif)
<br/>
