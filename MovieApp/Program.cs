using MovieApp.Models;
using System;
using System.Linq;

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            var db = new EFContext();

           


            Console.WriteLine("Welcome to the Application\n\n");

            while (true)
            {
                Console.WriteLine("\n\nSelect what you want to do from the option \n(1) Add Movie\n(2) Delete Movie \n(3) Add Actor\n(4) Delete Actor\n(5) List of Movies\n(6) List of Actors\n(7) Assign Actor to Movie \n(8) Exit ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.Write("Enter Movie Name : ");
                        string name = Console.ReadLine();

                        var isAdded = db.Movies.Where(t => t.MovieName == name);
                        if (isAdded.Count() >= 1)
                        {
                            Console.WriteLine("Movie is already Added");
                        }
                        else
                        {
                            Console.Write("\nEnter Producer of Movie : ");
                            string producer = Console.ReadLine();
                            Console.Write("\nEnter Duration of Movie : ");
                            int duration = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nEnter Type of Movie : ");
                            string type = Console.ReadLine();
                            Movie movie = new Movie(name,producer,duration,type);
                            try
                            {
                                db.Movies.Add(movie);
                                db.SaveChanges();
                                Console.WriteLine("Movie is added successfully..");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter movie name to delete : ");
                        string movDel = Console.ReadLine();
                        var delMovie = db.Movies.Where(t => t.MovieName == movDel);

                        if (delMovie.Count() == 1)
                        {
                            try
                            {
                                db.Movies.Remove(db.Movies.Single(t => t.MovieName == movDel));
                                db.SaveChanges();
                                Console.WriteLine("Movie is removed !!");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Movie is not in the list..");
                        }
                        break;
                    case 3:
                        Console.Write("Enter Actor Name : ");
                        string actName = Console.ReadLine();

                        var isActor = db.Actors.Where(t => t.ActorName == actName);

                        if (isActor.Count() >= 1)
                        {
                            Console.WriteLine("Actor is already in the list ");
                        }
                        else
                        {
                            
                            try
                            {
                                Console.Write("\nEnter Mobile number of Actor : ");
                                int mob =Convert.ToInt32( Console.ReadLine());
                                Console.Write("\nEnter email of Actor : ");
                                string email = Console.ReadLine();
                                Console.Write("\nEnter Gender of Actor: ");
                                string gen = Console.ReadLine();
                                Actor actor = new Actor(actName, mob,email,gen);
                                db.Actors.Add(actor);
                                db.SaveChanges();
                                Console.WriteLine("Actor is added..");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                        }
                        break;
                       
                    case 4:
                        Console.WriteLine("Enter Actor name to delete : ");
                        string delAct = Console.ReadLine();
                        var delActor = db.Actors.Where(t => t.ActorName == delAct);

                        if (delActor.Count() == 1)
                        {
                            try
                            {
                                db.Actors.Remove(db.Actors.Single(t => t.ActorName == delAct));
                                db.SaveChanges();
                                Console.WriteLine("Actor is deleted");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Movie is not available in the list");
                        }
                        break;
                    case 5:
                        var movieList = db.Movies;
                        try
                        {
                            foreach (var movie in movieList)
                            {

                                Console.WriteLine("Movie Name : " + movie.MovieName+" Movie Type : "+movie.Type);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 6:
                        var actorList = db.Actors;
                        try
                        {
                            foreach (var actor in actorList)
                            {

                                Console.WriteLine("Actor Name : " + actor.ActorName+" Actor Gender : "+actor.Gender);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 7:
                        Console.Write("\nEnter Actor name to assign movie : ");
                        var actorName = Console.ReadLine();
                        Console.Write("\nEnter Movie name to which assign Actor : ");
                        var movieName = Console.ReadLine();
                        var isMovieAddedCount = db.Movies.Where(t => t.MovieName == movieName);
                        
                        var isActorAddedCount = db.Actors.Where(t => t.ActorName == actorName);
                        
                        if(isMovieAddedCount.Count()>=1 && isActorAddedCount.Count()>=1)
                        {
                            var isMovieAdded = db.Movies.First(t => t.MovieName == movieName);
                            var isActorAdded = db.Actors.First(t => t.ActorName == actorName);
                            MovActRelationship movActRelationship = new MovActRelationship(isMovieAdded.MovieId, isActorAdded.ActorId);
                            db.MovActRelationships.Add(movActRelationship);
                            db.SaveChanges();
                            Console.WriteLine("Actor Assigned to movie");
                        }
                        else
                        {
                            Console.WriteLine("Movie or Actor is not Added");
                        }

                        break;
                    case 8:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
