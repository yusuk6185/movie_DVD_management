using Assignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class LibrarySystem : ILibrarySystem
    {
        IMemberCollection _members;
        IMovieCollection _movies;

        // add DVDs of a new movie to the system
        public void add(IMovie aMovie)
        {
            _movies.add(aMovie);
        }
        //add new DVDs of an existing movie to the system
        public void add(IMovie aMovie, int quantity)
        {
            aMovie.AvailableCopies += quantity;
        }
        //remove a given movie from the system
        public void delete(IMovie aMovie)
        {
            _movies.delete(aMovie);
        }
        //add a new memeber to the system
        public void add(IMember aMember)
        {
            _members.add(aMember);
        }
        //delete a member from the system
        public void delete(IMember aMember)
        {
            _members.delete(aMember);
        }
        //given a member's first name and last name, find the contact phone number of this member
        public string[] getConnectPhone(string firstname, string lastname)
        {
            // Original return type was string, but changed to return several types because first name and last name can be duplicated
            var members = _members.toArray();
            var results = new List<string>();
            for(var i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == firstname && members[i].LastName == lastname) results.Add(members[i].ContactNumber);
            }

            return results.ToArray();
        }
        //given the title of a movie, return all thoe memebrs wo are currently borrowing that movie
        public IMemberCollection getBorrowers(string movieTitle)
        {
            var movie = _movies.search(new Movie(movieTitle, null, 0, 0, 0));
            if(movie != null) return movie.getBorrowers;
            else return null;
        }

        //display the information about all the movies in the library
        public void displayAllMovies()
        {
            var movies = _movies.toArray();

            // Sort movie list
            bool isSorted;
            do
            {
                isSorted = true;
                for (var i = 0; i < movies.Length - 1; i++)
                {
                    if (string.Compare(movies[i].Title, movies[i + 1].Title) > 0)
                    {
                        IMovie temp = movies[i];
                        movies[i] = movies[i + 1];
                        movies[i + 1] = temp;
                        isSorted = false;
                    }
                }
            } while (!isSorted);

            Console.WriteLine(" ========== Movie Information ========== ");
            for (var i = 0; i < movies.Length; i++)
            {
                Console.WriteLine(movies[i].ToString());
                Console.WriteLine(" ======================================== ");
            }
            if (movies.Length == 0)
            {
                Console.WriteLine("\n                Empty\n");
                Console.WriteLine(" ======================================== ");
            }
        }
        //display all the information about about amovie, given the title of the movie 
        public void displayOneMovie(string movieTitle)
        {
            var movie = _movies.search(new Movie(movieTitle, null, 0, 0, 0));

            Console.WriteLine(" ========== Movie Information ========== ");
            if (movie == null) Console.WriteLine("\n Movie not found\n");
            else Console.WriteLine(movie.ToString());
            Console.WriteLine(" ======================================== ");
        }
        //a member borrows a movie DVD from the library
        public void borrowMovie(IMember aMember, IMovie aMovie)
        {
            aMember.addMovie(aMovie);
            aMovie.addBorrower(aMember);
            aMovie.NoBorrowings++;
        }
        //a member returns a movie DVD to the library
        public void returnMovie(IMember aMember, IMovie aMovie)
        {
            aMember.deleteMovie(aMovie);
            aMovie.deleteBorrower(aMember);
            aMovie.NoBorrowings--;
        }
        //get a list of movie DVDs that are currently hold by a given member
        public string[] getMovieDVDs(IMember aMember)
        {
            return aMember.getBorrowingMovieDVDs;
        }
        //Display top three most frequently borrowed movies by the members in the library in the descending order by the number of times the movie has been borrowed.
        public void displayTop3()
        {
            var movies = _movies.toArray();

            bool isSorted;
            do
            {
                isSorted = true;
                for (var i = 0; i < movies.Length - 1; i++)
                {
                    if ((movies[i] as Movie).BorrowCount < (movies[i + 1] as Movie).BorrowCount)
                    {
                        IMovie tmp = movies[i];
                        movies[i] = movies[i + 1];
                        movies[i + 1] = tmp;
                        isSorted = false;
                    }
                }
            } while (!isSorted);

            Console.WriteLine(" ================== Top 3 ===================");
            for(var i = 0; i < 3 && i < movies.Length; i++)
            {
                Console.WriteLine($" [{i + 1}] {movies[i].Title}");
                Console.WriteLine($"      Frequency : {(movies[i] as Movie).BorrowCount}");
                Console.WriteLine(" ============================================");
            }
            if (movies.Length == 0)
            {
                Console.WriteLine("\n                 Empty\n");
                Console.WriteLine(" ============================================");
            }
        }

        #region Menu Utils
        enum MenuType 
        { 
            Exit, 
            Main = 3, 
            Staff = 8, 
            Member = 7, 
        }
        int printMenu(MenuType menuType)
        {
            int select;
            bool error = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===========================================================");
                Console.WriteLine("       COMMUNITY LIBRARY MOVIE DVD MANAGEMENT SYSTEM       ");
                Console.WriteLine("===========================================================");
                Console.WriteLine();

                switch (menuType)
                {
                    case MenuType.Main:
                        Console.WriteLine(" Main Menu");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine(" 1. Staff");
                        Console.WriteLine(" 2. Member");
                        Console.WriteLine(" 0. End the program");
                        Console.WriteLine(error ? " !!Wrong Number!!" : "");
                        break;

                    case MenuType.Staff:
                        Console.WriteLine(" Staff Menu");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine(" 1. Add DVDs of a new movie to the system");
                        Console.WriteLine(" 2. Add new DVDs of an existing movie to the system");
                        Console.WriteLine(" 3. Remove a DVD from the system");
                        Console.WriteLine(" 4. Register a new member to the system");
                        Console.WriteLine(" 5. Remove a registered member from the system");
                        Console.WriteLine(" 6. Find a member's contact phone number, given the member's name");
                        Console.WriteLine(" 7. Find members who are currently renting a particular movie");
                        Console.WriteLine(" 0. Return to main menu");
                        Console.WriteLine(error ? " !!Wrong Number!!" : "");
                        break;

                    case MenuType.Member:
                        Console.WriteLine(" Member Menu");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine(" 1. Browse all the movies");
                        Console.WriteLine(" 2. Display all the information about a movie, given the title of the movie");
                        Console.WriteLine(" 3. Borrow a movie DVD");
                        Console.WriteLine(" 4. Return a movie DVD");
                        Console.WriteLine(" 5. List current borrowing movies");
                        Console.WriteLine(" 6. Display the top 3 movies rented by the members");
                        Console.WriteLine(" 0. Return to main menu");
                        Console.WriteLine(error ? " !!Wrong Number!!" : "");
                        break;
                }

                error = false;
                Console.Write(" Enter your choice ==> ");
                select = inputNumber();
                if (select >= (int)menuType) error = true;
                else break;
            }

            return select;
        }
        int inputNumber()
        {
            var builder = new StringBuilder();
            do
            {
                // Bring input key
                var key = Console.ReadKey(true);
                // Escape if the key is enter
                if (key.Key == ConsoleKey.Enter && builder.Length != 0) break;
                // Ignore if the key is not a number
                if (!(key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9) || !(key.Key >= ConsoleKey.NumPad0 || key.Key <= ConsoleKey.NumPad9)) continue;

                // Display in console and builder if the key is a number
                builder.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            } while (true);

            Console.WriteLine();
            // Return the numbers in builder after converting to int
            return int.Parse(builder.ToString());
        }
        // Function that receives the password from the user
        string inputPassword(char passwordChar = '●', bool isPin = false)
        {
            var builder = new StringBuilder();
            do
            {
                var key = Console.ReadKey(true);
                if (isPin)
                {   // Enter is available after inputing 4 PIN numbers 
                    if (key.Key == ConsoleKey.Enter && builder.Length == 4) break;
                    if (builder.Length == 4 || !(key.Key >= ConsoleKey.D0 && key.Key <= ConsoleKey.D9) || !(key.Key >= ConsoleKey.NumPad0 || key.Key <= ConsoleKey.NumPad9)) continue;
                }
                else if (key.Key == ConsoleKey.Enter) break;

                builder.Append(key.KeyChar);
                Console.Write(passwordChar);

            } while (true);

            Console.WriteLine();
            return builder.ToString();
        }
        // Function that enables the user to input anything on the program
        void pressAnyKey()
        {
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey(true);
        }
        // Function that enable Y (continue) and Y (return)
        bool inputYorN()
        {
            Console.WriteLine("Press Y to keep going, or N to return to the back menu...");
            do
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y) return true;
                else if (key.Key == ConsoleKey.N) return false;
            } while (true);
        }
        #endregion

        #region Staff Menus
        // Add new movie
        void staff_addNewDvd()
        {
            Console.Clear();
            Console.WriteLine(" Add DVDs of a new movie to the system");

            // Create new object for new movie
            IMovie movie = new Movie();

            // get information about the movie
            do
            {
                Console.Write(" Title : ");
                movie.Title = Console.ReadLine();
                // if the movie title exists in the library, error message
                if (_movies.search(movie) != null)
                {
                    Console.WriteLine(" Same title is already in movie list.");
                    if (!inputYorN()) return;
                    continue;
                }
                else break;
            } while (true);

            // Genre
            Console.Write(" Genre : ");
            movie.Genre = Console.ReadLine();
            // Classification
            do
            {
                Console.Write(" Classification : ");
                string c = Console.ReadLine();
                switch (c.ToUpper())
                {
                    case "G":
                    case "GENERAL":
                        movie.Classification = 0;
                        break;

                    case "PG":
                    case "PARENTAL GUIDANCE":
                        movie.Classification = 1;
                        break;

                    case "M15+":
                    case "MATURE":
                        movie.Classification = 2;
                        break;

                    case "MA15+":
                    case "MATURE ACCOMPANIED":
                        movie.Classification = 3;
                        break;

                    default:
                        movie.Classification = -1;
                        Console.WriteLine(" Wrong classification. You can input only 'G', 'PG', 'M15+' and 'MA15+'.");
                        break;
                }
            } while (movie.Classification == -1);

            // Duration
            Console.Write(" Duration : ");
            movie.Duration = inputNumber();
            // Number of available copies
            Console.Write(" Available Copies : ");
            movie.AvailableCopies = inputNumber();

            // add new movie object to the array
            add(movie);

            Console.WriteLine(" Movie added completely.");
            pressAnyKey();
        }
        // add number of DVDs to existing movie
        void staff_addExistingDvd() 
        {   
            Console.Clear();
            Console.WriteLine(" Add new DVDs of an existing movie to the system");
            IMovie movie = new Movie();
            Console.Write(" Title : ");
            movie.Title = Console.ReadLine();

            movie = _movies.search(movie);
            if (movie == null)
            {
                Console.WriteLine(" Movie not found.");
                pressAnyKey();
                return;
            }

            Console.Write(" How many copies to add : ");
            int count = inputNumber();

            add(movie, count);

            Console.WriteLine($" Copies added complete. ({movie.AvailableCopies - count} -> {movie.AvailableCopies})");
            pressAnyKey();
        }
        // remove movie
        void staff_removeDvd() 
        {
            Console.Clear();
            Console.WriteLine(" Remove a DVD from the system");
            IMovie movie = new Movie();
            Console.Write(" Title : ");
            movie.Title = Console.ReadLine();

            movie = _movies.search(movie);
            if (movie == null)
            {
                Console.WriteLine(" Movie not found.");
                Console.WriteLine(" Press any key to continue...");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine(" The movie information will be permanently deleted.");
            if (!inputYorN()) return;

            delete(movie);

            Console.WriteLine(" DVD removed.");
            pressAnyKey();
        }
        // register new member
        void staff_registerNewMember() 
        {
            Console.Clear();
            Console.WriteLine(" Register a new member to the system");
            IMember member = new Member();

            Console.Write(" First Name : ");
            member.FirstName = Console.ReadLine();
            Console.Write(" Last Name : ");
            member.LastName = Console.ReadLine();
            do
            {
                Console.Write(" Contact Number : ");
                member.ContactNumber = Console.ReadLine();
                if (_members.search(member) != null)
                {
                    Console.WriteLine(" Same contact number is already in member list.");
                    if (!inputYorN()) return;
                    continue;
                }
                else break;
            } while (true);

            do
            {
                Console.Write(" PIN : ");
                member.Pin = int.Parse(inputPassword(isPin: true));
                Console.Write(" PIN Again : ");
                int check = int.Parse(inputPassword(isPin: true));
                if (member.Pin != check)
                {
                    Console.WriteLine(" PINs are not same.");
                    if (!inputYorN()) return;
                    continue;
                }
                else break;
            } while (true);

            add(member);

            Console.WriteLine(" Member added completely.");
            pressAnyKey();
        }
        // remove existing member
        void staff_removeMember() 
        {
            Console.Clear();
            Console.WriteLine(" Remove a registered member from the system");
            IMember member = new Member();
            Console.Write(" Contact : ");
            member.ContactNumber = Console.ReadLine();

            member = _members.search(member);
            if (member == null)
            {
                Console.WriteLine(" Member not found.");
                pressAnyKey();
                return;
            }

            Console.WriteLine(" The member information will be permanently deleted.");
            if (!inputYorN()) return;

            delete(member);

            Console.WriteLine(" Member removed.");
            pressAnyKey();
        }
        // search the phone number of the user with the member name
        void staff_findMember() 
        {
            Console.Clear();
            Console.WriteLine(" Find a member's contact phone number, given the member's name");

            string first, last;
            Console.Write(" First Name : ");
            first = Console.ReadLine();
            Console.Write(" Last Name : ");
            last = Console.ReadLine();

            Console.WriteLine(" ============= Search Results ================");
            var list = getConnectPhone(first, last);
            for(var i = 0; i < list.Length; i++)
            {
                Console.WriteLine($" [{i + 1}] {list[i]}");
            }
            if(list.Length == 0)
            {
                Console.WriteLine("\n         Empty\n");
            }
            Console.WriteLine(" ==============================================");

            pressAnyKey();
        }
        // search member who borrowed the particular movie
        void staff_getRentingMembers() 
        {
            Console.Clear();
            Console.WriteLine("Find members who are currently renting a particular movie");

            IMovie movie = new Movie();
            Console.Write(" Title : ");
            movie.Title = Console.ReadLine();

            movie = _movies.search(movie);
            if (movie == null)
            {
                Console.WriteLine(" Movie not found.");
                pressAnyKey();
                return;
            }

            var borrowers = movie.getBorrowers.toArray();
            foreach (var m in borrowers) Console.WriteLine(m.ToString());

            pressAnyKey();
        }
        #endregion

        #region Member Menus
        void member_browsAllMovies() 
        {
            Console.Clear();
            Console.WriteLine(" Browse all the movies");

            displayAllMovies();
            pressAnyKey();
        }
        void member_searchWithTitle() 
        {
            Console.Clear();
            Console.WriteLine(" Movie information");

            Console.Write(" Title : ");

            displayOneMovie(Console.ReadLine());
            pressAnyKey();
        }
        void member_borrowMovie(IMember account) 
        {
            Console.Clear();
            Console.WriteLine(" Borrow a movie DVD");

            IMovie movie = new Movie();
            Console.Write(" Title : ");
            movie.Title = Console.ReadLine();

            movie = _movies.search(movie);
            if (movie == null)
            {
                Console.WriteLine(" Movie not found.");
                Console.WriteLine(" Press any key to continue...");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine($" Would you really want to borrow movie [{movie.Title}]?");
            if (!inputYorN()) return;

            if (account.getBorrowingMovieDVDs.Length == 5)
            {
                Console.WriteLine(" You can only rent up to 5 movies at the same time.");
                pressAnyKey();
                return;
            }
            if (movie.NoBorrowings == movie.AvailableCopies)
            {
                Console.WriteLine(" There are not enough copies available to borrow DVDs.");
                pressAnyKey();
                return;
            }

            borrowMovie(account, movie);

            Console.WriteLine(" Borrowing complete.");
            pressAnyKey();
        }
        void member_returnMovie(IMember account)
        {
            Console.Clear();
            Console.WriteLine(" Return a movie DVD");

            Console.WriteLine(" Here is the list of titles you borrow. Select number you want to return.");
            Console.WriteLine(" ============= Your borrowings =============");

            var list = account.getBorrowingMovieDVDs;
            if (list.Length == 0)
            {
                Console.WriteLine("Empty");
                pressAnyKey();
                return;
            }
            else
            {
                for (var i = 0; i < list.Length; i++)
                {
                    Console.WriteLine($" [{i + 1}] {list[i]}");
                }
            }

            Console.WriteLine(" ===========================================");

            int index;
            do
            {
                Console.Write(" Select number ==> ");
                if ((index = (inputNumber() - 1)) >= list.Length || index < 0)
                {
                    Console.WriteLine(" Wrong number!!");
                    if (inputYorN()) return;
                    continue;
                }
                else break;
            } while (true);

            IMovie movie = _movies.search(new Movie(list[index], null, 0, 0, 0));
            returnMovie(account, movie);

            Console.WriteLine(" Movie returned.");
            pressAnyKey();
        }
        void member_listBorrowings(IMember account) 
        {
            Console.Clear();
            Console.WriteLine(" ============= Your borrowings =============");

            var list = getMovieDVDs(account);
            if (list.Length == 0)
            {
                Console.WriteLine("\n            Empty\n");
            }
            else
            {
                for (var i = 0; i < list.Length; i++)
                {
                    Console.WriteLine($" [{i + 1}] {list[i]}");
                }
            }

            Console.WriteLine(" ===========================================");
            pressAnyKey();
        }
        void member_displayTop3() 
        {
            Console.Clear();
            displayTop3();
            pressAnyKey();
        }
        #endregion

        // main menu
        MenuType mainMenu()
        {
            switch (printMenu(MenuType.Main))
            {
                case 0:
                    return MenuType.Exit;

                case 1:
                    return MenuType.Staff;

                case 2:
                    return MenuType.Member;
            }

            throw new Exception("Unknown error.");
        }
        // staff menu
        MenuType staffMenu() 
        {
            // staff login
            string id, password;
            Console.Clear();
            Console.WriteLine("You must enter staff ID and Password to asccess staff page.");
            Console.Write("Staff ID : ");
            id = Console.ReadLine();
            Console.Write("Staff Password : ");
            password = inputPassword();
            if(id != "staff" || password != "today123")
            {
                Console.WriteLine("Wrong ID or Password!");
                pressAnyKey();
                // return to main menu if the authentication fails
                return MenuType.Main;
            }

            // return staff menu when logged in
            do
            {
                switch (printMenu(MenuType.Staff))
                {
                    case 0:
                        return MenuType.Main;

                    case 1:
                        staff_addNewDvd();
                        break;

                    case 2:
                        staff_addExistingDvd();
                        break;

                    case 3:
                        staff_removeDvd();
                        break;

                    case 4:
                        staff_registerNewMember();
                        break;

                    case 5:
                        staff_removeMember();
                        break;

                    case 6:
                        staff_findMember();
                        break;

                    case 7:
                        staff_getRentingMembers();
                        break;
                }
            } while (true);
        }
        // member menu
        MenuType memberMenu() 
        {
            Member current = null;

            // member login
            string firstname, lastname, password;
            Console.Clear();
            Console.WriteLine("Please enter your login information to access member page.");
            Console.Write("First Name : ");
            firstname = Console.ReadLine();
            Console.Write("Last Name : ");
            lastname = Console.ReadLine();
            Console.Write("PIN (four-digit) : ");
            password = inputPassword(isPin:true);

            // save member to current whose name and PIN corresponds 
            var members = _members.toArray();
            for(var i = 0; i < members.Length; i++)
            {
                if (members[i].FirstName == firstname && members[i].LastName == lastname && members[i].Pin == int.Parse(password))
                {
                    current = members[i] as Member;
                    break;
                }
            }
            // if there is nothing corresponds in current, authentication fails and return to main menu
            if(current == null)
            {
                Console.WriteLine("Wrong ID or Password!");
                pressAnyKey();
                return MenuType.Main;
            }

            // borrow, return, list need user information so send them to current which is current member
            do
            {
                switch (printMenu(MenuType.Member))
                {
                    case 0:
                        return MenuType.Main;

                    case 1:
                        member_browsAllMovies();
                        break;

                    case 2:
                        member_searchWithTitle();
                        break;

                    case 3:
                        member_borrowMovie(current);
                        break;

                    case 4:
                        member_returnMovie(current);
                        break;

                    case 5:
                        member_listBorrowings(current);
                        break;

                    case 6:
                        member_displayTop3();
                        break;
                }
            } while (true);
        }

        public void Run()
        {
            // receive next position to menu and move to next position
            MenuType menu = MenuType.Main;

            do
            {
                switch (menu)
                {
                    case MenuType.Main:
                        menu = mainMenu();
                        break;

                    case MenuType.Staff:
                        menu = staffMenu();
                        break;

                    case MenuType.Member:
                        menu = memberMenu();
                        break;
                }
            } while (menu != MenuType.Exit) ;
        }
        public LibrarySystem()
        {
            _members = new MemberCollection();
            _movies = new MovieCollection();
        }
    }
}
