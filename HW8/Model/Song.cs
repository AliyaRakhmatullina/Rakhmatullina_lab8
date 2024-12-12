using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Model
{
    public class Song
    {
        private string name; //название песни
        private string author; //автор песни
        private Song prev; //связь с предыдущей песней в списке

        //метод для заполнения поля name
        public void SetName(string name)
        {
            this.name = name;
        }

        //метод для заполнения поля author
        public void SetAuthor(string author)
        {
            this.author = author;
        }

        //метод для заполнения поля prev
        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        //метод для печати названия песни и ее исполнителя
        public string Title() {
            /*возвращ название+исполнитель*/

            return name + " - " + author;
        }

        //метод, который сравнивает между собой два объекта-песни:
        public override bool Equals(object? d)
        {
            if (d is Song)
            {
                Song s = d as Song;
                return author == s.author && name == s.name;
            }
            return false;
        }
    }
}
