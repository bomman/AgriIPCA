﻿using System.Text;

namespace AgriIPCA.Models.Users
{
    public abstract class Person
    {
        protected Person(string username, string password, string address)
        {
            this.Username = username;
            this.Password = password;
            this.Address = address;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            return $"{this.Id};{this.Username};{this.Password};{this.Address}";
        }

        public virtual string PrintDetails()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Username: {this.Username}");
            output.Append($"Address: {this.Address}");

            return output.ToString();
        }
    }
}
