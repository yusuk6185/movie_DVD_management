# Introduction
The goal of this project is to develop a **C# based console software application** for a **community
library to manage its movie DVDs**. There are staff and member menu in this application which can
be selected in the main menu. Both menu can be accessed with the authentication. The staff menu
is basically used to manage movie, DVDs, and member in the system. On the other hand, the
member menu is created to function to borrow, return, and check information of the movie. In
addition, a function to identify the top 3 movies which are most frequently borrowed by the
members is developed using bubble sort. Lastly, the hash table data structure is used to store the
movie data. 

# Design and Analysis of Algorithms
To display top three most frequently borrowed movie DVDs in descending order by the number of
times that the movie DVDs have been borrowed, the bubble sort has been used in the algorithm.
First, sort the whole movie array by BorrowCount. Then, to check the array is sorted, give isSorted
value of true. Next, compare the elements(movies) in the array from 0 to -1. Then, move the movie
with the smaller BorrowCount between i and i+1. If there happens a switch, give isSorted value of
false. Lastly, if the isSorted is false, it means the loop must continue because the array needs to be
checked if it is fully sorted. Otherwise, if isSorted is true, it means the switch did not happen which
concludes that the array is fully sorted and escape the loop.

## Pseudo Code
![image](https://user-images.githubusercontent.com/35501963/144554694-37d18f74-40df-4a19-9213-ae5b7773861a.png)
![image](https://user-images.githubusercontent.com/35501963/144554703-391bbf05-8079-4be0-8a1c-dcdbd633a70e.png)

The time efficiency or complexity of the algorithm used, bubble sort, is O(n^2) because the
comparison occurs n^2 times in worst case. In bubble sort, the outer loop repeats n-1 times and
inner loop repeats n-1-I times. Therefore, the total comparison occurs (n-1) (n-1-i) times which leads
to O(n^2). 

## Hash Table
Since the hash table data structure is considered as efficient method to store the movie data, the
system generic library of C# is used to create hash table. Hash table stores data to the key dictionally
that has O(n) of time complexity in the worst case.

![image](https://user-images.githubusercontent.com/35501963/144554755-ef06f5ea-21da-4746-bfe3-daf75bd415ab.png)

The following code is created to add data to the hash table.

![image](https://user-images.githubusercontent.com/35501963/144554787-2547aa09-83ed-4f6f-b6da-f3d5420d3756.png)

The following code is to delete data in the hash table.

![image](https://user-images.githubusercontent.com/35501963/144554826-323b66c3-1ba8-4847-abae-a4a7da2d4345.png)

The following code is to search in the hash table with movie title

![image](https://user-images.githubusercontent.com/35501963/144554855-3f31e30a-f919-484e-8fba-d592f4041811.png)

The following code is to remove all the data in the hash table.

![image](https://user-images.githubusercontent.com/35501963/144554877-a31b68ba-15dc-4f04-aaa2-f5964b38d8fd.png)

# Test Plan and Test Results
The test plan for this console application is based on the required functions in the project
specification.
![image](https://user-images.githubusercontent.com/35501963/144554942-dc6bcc87-1980-4808-ad6c-a7647a980e0e.png)

![image](https://user-images.githubusercontent.com/35501963/144554968-21240f8b-d9da-440f-a834-3092bef1faca.png)
![image](https://user-images.githubusercontent.com/35501963/144554987-2e2e62b5-2004-44fa-a69e-efc0f7a96a91.png)

The application is designed and developed to achieve these tasks successfully and manually tested
with the manually generated member and movie data while testing the application. The specification
which is not included in the list above is also tested. The other test plan is as followed:

![image](https://user-images.githubusercontent.com/35501963/144555006-60ba190a-8220-4aef-8fd2-79ce3740ef23.png)

The result of the testing turned out to successful by passing all of the testing specifications. The
following images are the screenshots of successful testing.

### The software application should have a staff menu that allows the staff to do the following:

#### Staff menu

![image](https://user-images.githubusercontent.com/35501963/144555067-1efa5996-86ea-4efe-89d6-677027deba0e.png)

#### Add DVDs of a new movie to the system. 

![image](https://user-images.githubusercontent.com/35501963/144555089-ad9a51c6-3025-41f2-852c-6da2336bb227.png)

![image](https://user-images.githubusercontent.com/35501963/144555100-6dfc8a81-1be1-47ce-ab13-880135bef0f1.png)

#### Add DVDs of an existing movie to the system.

![image](https://user-images.githubusercontent.com/35501963/144555128-4db01cf1-9a32-498f-8972-8c2d51888b5a.png)

#### Remove DVDs of a movie from the system – if all the DVDs of a movie are removed, the movie should also be removed from the system. 

![image](https://user-images.githubusercontent.com/35501963/144555144-c93981df-5e8c-45bf-9e5f-8d5ebf4d1d1d.png)

#### Register a new member with the system. When a member is being registered via a staff member, a four-digit password is set for the member.

![image](https://user-images.githubusercontent.com/35501963/144555160-b326276d-84d8-4b20-a2b4-673920a40e94.png)


#### Remove a registered member from the system. 

![image](https://user-images.githubusercontent.com/35501963/144555178-a9a9e6fb-6a12-4f8f-ac96-2a3c9585b9c4.png)

#### Find a member’s contact phone number, given the member’s full name.

![image](https://user-images.githubusercontent.com/35501963/144555201-95512c1b-9c72-4be7-89b0-fb83b31574f9.png)

#### Find all the members who are currently renting a particular movie. 

![image](https://user-images.githubusercontent.com/35501963/144555224-b738542a-81cc-44d5-89ad-b30aaa7d6201.png)
