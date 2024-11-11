using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Book
    {
        //Atributos - Caracteristicas o propiedas que los objetos van a tener
        //Niveles de acceso: public private protected

        private string Title { get; set; }
        private string Author { get; set; }
        private int PublicationDate { get; set; }
        private int PageNumber { get; set; }




        //Constructor - Instruccion que permite definir como instanciar un objeto

        public Book(string title, string author, int date, int pages)
        {
            this.Title = title;
            this.Author = author;
            this.PublicationDate = date;
            this.PageNumber = pages;

        }

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;

        }

        //Metodos

        public void DisplayInfo()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Publication Date: {PublicationDate}");
            Console.WriteLine($"Page Number: {PageNumber}");
            
        }

        public string Avaliable()
        {
            return "Book avaliable for rent";
        }


    }
}
