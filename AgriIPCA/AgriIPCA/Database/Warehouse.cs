using System;
using System.Collections.Generic;
using System.Text;
using AgriIPCA.Interfaces;
using AgriIPCA.IO;
using AgriIPCA.Models.Products;
using AgriIPCA.Models.Users;

namespace AgriIPCA.Database
{
    public class Warehouse
    {
        private IFactory personsFactory;
        private IFactory productsFactory;
        private static int personsLastId = 0;
        private static int productsLastId = 0;

        public Warehouse()
        {
            personsFactory = new PersonsFactory();
            productsFactory = new ProductsFactory();
            this.Persons = new Dictionary<string, Person>();
            this.Products = new Dictionary<int, Product>();
            this.ReadPersons();
            this.ReadProducts();
        }

        private void ReadProducts()
        {
            //TODO: readProducts
        }

        public void ReadPersons()
        {
            string data = this.personsFactory.Read();
            if (data != "")
            {
                string[] persons = data.Split('\n');
                foreach (var person in persons)
                {
                    if (person != "")
                    {
                        string[] personArgs = person.Split(';');
                        Person newPerson = new User(personArgs[1], personArgs[2], personArgs[3]);
                        newPerson.Id = int.Parse(personArgs[0]);
                        personsLastId = newPerson.Id;
                        this.Persons.Add(newPerson.Username, newPerson);
                    }
                }
            }
        }

        public IDictionary<string, Person> Persons { get; private set; }

        public IDictionary<int, Product> Products { get; private set; }

        public void AddPerson(Person person)
        {
            if (this.Persons.ContainsKey(person.Username))
            {
                throw new Exception("There is a user with the same username. Enter 1 to create again user. ");
            }

            person.Id = this.SetId();
            this.Persons.Add(person.Username, person);
            this.personsFactory.Write(person.ToString());
        }

        private int SetId()
        {
            return ++personsLastId;
        }

        public Person UpdateUser(Person user, string username, string password, string address)
        {
            Person currentPerson = this.Persons[user.Username];
            currentPerson.Username = username;
            currentPerson.Password = password;
            currentPerson.Address = address;

            StringBuilder output = new StringBuilder();
            foreach (var person in this.Persons.Values)
            {
                output.Append(person.ToString() + "\n");
            }

            this.personsFactory.Update(output.ToString());

            return currentPerson;
        }
    }
}
