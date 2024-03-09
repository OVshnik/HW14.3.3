using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;
using TelBook;
using System.Diagnostics;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

namespace TelBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var sortPhoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(y => y.LastName);

            while (true)
            {
                var UserInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();  


                if (UserInput <= 0||UserInput>3)
                {
                    Console.WriteLine("Ошибка ввода, введите число");
                }
                else
                {
                    IEnumerable<Contact> page = null;

                    switch (UserInput)
                    {
                        case (1):
                            page = sortPhoneBook.Take(2);
                            break;
                        case (2):
                            page = sortPhoneBook.Skip(2).Take(2);
                            break;
                        case (3):
                            page = sortPhoneBook.Skip(4);
                            break;
                    }
                    foreach (var contact in page)
                        Console.WriteLine(contact.Name + ","+contact.LastName+"," + contact.PhoneNumber + "," + contact.Email);
                }
            }
        }
        }
    }
