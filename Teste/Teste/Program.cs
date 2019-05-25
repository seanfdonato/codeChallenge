using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            //getNumberOfMovies("maze");
            //shortestPalindrome("abab");
            shortestPalindrome("abcda");
            var pm = new PersonManager();
            var p = new Person(1, "Chico", DateTime.Now);
            pm.AddPerson(p);
            pm.DeletePerson(p);
        }

        public static void shortestPalindrome(string palindrome)
        {
            char[] arr = palindrome.ToCharArray();
            string strReverted = new string(palindrome.Reverse().ToArray());
            int i = 0;
            while (true)
            {
                if (arr[i] == arr[arr.Length - 1 - i])
                {
                    i++;
                }
                else
                {
                    char[] t = new char[arr.Length];
                    Array.Copy(arr, 0, t, 0, i+1);
                    Array.Copy(arr, 0, t, 0, i + 1);
                }
            }
        }

        public static string revert(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        static int getNumberOfMovies(string substr)
        {
            try
            {
                var uri = "https://jsonmock.hackerrank.com/api/movies/search/?Title=";
                var request = WebRequest.CreateHttp(uri + substr);
                request.Method = "GET";
                request.ContentType = "application/json";
                using (var resposta = request.GetResponse())
                {
                    var streamData = resposta.GetResponseStream();
                    using (StreamReader reader = new StreamReader(streamData))
                    {
                        object objResponse = reader.ReadToEnd();
                        Result result = JsonConvert.DeserializeObject<Result>(objResponse.ToString());
                        streamData.Close();
                        resposta.Close();
                        return result.Total;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }


        }
    }
    class Result
    {
        public string Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public IEnumerable<Movie> Data { get; set; }
    }
    class Movie
    {
        public string Poster { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
    }

    public class Person
    {
        public Person(int id, string nome, DateTime birthDate)
        {
            Name = nome;
            Age = CalcAge(birthDate);
        }
        private int Id { get; set; }
        private string Name { get; set; }
        private int? Age { get; set; }

        private int CalcAge(DateTime _birthDate)
        {
            var today = DateTime.Now.Date;
            return _birthDate.Year - today.Year;
        }


    }
    public class PersonManager
    {
        public PersonManager()
        {
            DB = new List<Person>();
        }
        private static List<Person> DB { get; set; }
        public void AddPerson(Person person)
        {
            try
            {
                DB.Add(person);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeletePerson(Person person)
        {
            try
            {
                DB.Remove(person);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}
